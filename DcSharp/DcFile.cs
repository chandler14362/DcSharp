using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;

namespace DcSharp
{
    public class DcFile
    {
        private List<DcClass> _classes;

        private Dictionary<int, DcClass> _classesById;

        private Dictionary<string, DcDeclaration> _thingsByName;
        
        private List<DcTypedef> _typedefs;

        private Dictionary<string, DcTypedef> _typedefsByName;

        private DcKeywordList _keywords;

        private DcKeywordList _defaultKeywords;

        private List<DcDeclaration> _declarations;

        private List<DcField> _fieldsByIndex;

        private List<DcDeclaration> _thingsToDelete;

        private bool _allObjectsValid;

        private bool _inheritedFieldsStale;

        public int NumClasses => _classes.Count;

        public int NumTypedefs => _typedefs.Count;
        
        public DcFile()
        {
            _classes = new List<DcClass>();
            _classesById = new Dictionary<int, DcClass>();
            _thingsByName = new Dictionary<string, DcDeclaration>();
            _typedefs = new List<DcTypedef>();
            _typedefsByName = new Dictionary<string, DcTypedef>();
            _keywords = new DcKeywordList();
            _defaultKeywords = new DcKeywordList();
            _declarations = new List<DcDeclaration>();
            _fieldsByIndex = new List<DcField>();
            _thingsToDelete = new List<DcDeclaration>();
            _allObjectsValid = true;
            _inheritedFieldsStale = false;
            
            SetupDefaultKeywords();
        }

        public void Load(string file)
        {
            using var fs = new FileStream(file, FileMode.Open);
            Load(fs);
        }
        
        public void Load(Stream stream)
        {
            var inputStream = new AntlrInputStream(stream);
            var lexer = new DcTokens(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new DcParser(tokens);

            var walker = new ParseTreeWalker();
            var listener = new DcParserListener(this);
            
            walker.Walk(listener, parser.init());
            
            if (_inheritedFieldsStale)
                RebuildInheritedFields();
        }

        public bool AddClass(DcClass dclass)
        {
            if (dclass.Name != string.Empty)
            {
                if (!_thingsByName.TryAdd(dclass.Name, dclass))
                    return false;
            }

            if (!dclass.IsStruct)
            {
                _classesById[NumClasses] = dclass;
                dclass.Number = NumClasses;
            }
            
            _classes.Add(dclass);

            if (dclass.Bogus)
                _allObjectsValid = false;
            
            if (!dclass.Bogus)
                _declarations.Add(dclass);
            else
                _thingsToDelete.Add(dclass);

            return true;
        }

        public bool AddTypedef(DcTypedef dtypedef)
        {
            if (!_typedefsByName.TryAdd(dtypedef.Name, dtypedef))
                return false;

            dtypedef.Number = NumTypedefs;
            _typedefs.Add(dtypedef);

            if (dtypedef.IsBogus)
                _allObjectsValid = false;
            
            if (!dtypedef.IsBogus && !dtypedef.IsImplicit)
                _declarations.Add(dtypedef);
            else
                _thingsToDelete.Add(dtypedef);

            return true;
        }

        public bool AddKeyword(string name)
        {
            var keyword = new DcKeyword(name);
            var added = _keywords.AddKeyword(keyword);
            
            if (added)
                _declarations.Add(keyword);

            return added;
        }

        public DcKeyword? GetKeyword(string name)
        {
            if (_defaultKeywords.TryGetKeyword(name, out var keyword))
                return keyword;

            if (_keywords.TryGetKeyword(name, out keyword))
                return keyword;

            return null;
        }

        public bool TryGetKeyword(string name, out DcKeyword keyword)
        {
            keyword = GetKeyword(name);
            return keyword != null;
        }
        
        public DcClass? GetClassByName(string name)
        {
            if (!_thingsByName.TryGetValue(name, out var decl))
                return null;
            
            return decl as DcClass;
        }

        public bool TryGetClassByName(string name, out DcClass dclass)
        {
            dclass = GetClassByName(name);
            return dclass != null;
        }

        public DcClass? GetClassById(int id)
        {
            if (!_classesById.TryGetValue(id, out var dclass))
                return null;

            return dclass;
        }

        public bool TryGetClassById(int id, out DcClass dclass)
        {
            dclass = GetClassById(id);
            return dclass != null;
        }

        public bool TryGetTypedef(string name, out DcTypedef typedef)
        {
            return _typedefsByName.TryGetValue(name, out typedef);
        }

        public bool TryGetField<T>(int index, out T field) where T : DcField
        {
            if (!TryGetField(index, out var f))
            {
                field = null;
                return false;
            }

            field = f as T;
            return field != null;
        }
        
        public bool TryGetField(int index, out DcField field)
        {
            if (0 <= index && index <= _fieldsByIndex.Count - 1)
            {
                field = _fieldsByIndex[index];
                return true;
            }
            
            field = null;
            return false;
        }

        public void MarkInheritedFieldsStale()
        {
            _inheritedFieldsStale = true;
        }
        
        public void CheckInheritedFields()
        {}

        public void SetNewIndexNumber(DcField field)
        {
            field.Number = _fieldsByIndex.Count;
            _fieldsByIndex.Add(field);
        }

        public void RebuildInheritedFields()
        {
            _inheritedFieldsStale = false;

            foreach (var dclass in _classes)
                dclass.ClearInheritedFields();
            
            foreach (var dclass in _classes)
                dclass.RebuildInheritedFields();
        }

        private void SetupDefaultKeywords()
        {
            _defaultKeywords.ClearKeywords();
            _defaultKeywords.AddKeyword(new DcKeyword("required", 1));
            _defaultKeywords.AddKeyword(new DcKeyword("broadcast", 1 << 1));
            _defaultKeywords.AddKeyword(new DcKeyword("ownrecv", 1 << 2));
            _defaultKeywords.AddKeyword(new DcKeyword("ram", 1 << 3));
            _defaultKeywords.AddKeyword(new DcKeyword("db", 1 << 4));
            _defaultKeywords.AddKeyword(new DcKeyword("clsend", 1 << 5));
            _defaultKeywords.AddKeyword(new DcKeyword("clrecv", 1 << 6));
            _defaultKeywords.AddKeyword(new DcKeyword("ownsend", 1 << 7));
            _defaultKeywords.AddKeyword(new DcKeyword("airecv", 1 << 8));
        }

        public override string ToString()
        {
            var str = "";
            foreach (var declaration in _declarations)
                str += declaration.ToString() + "\n";
            return str;
        }
    }
}