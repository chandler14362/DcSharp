using System.Collections.Generic;
using System.Linq;

namespace DcSharp
{
    public class DcClass : DcDeclaration
    {
        public static bool MultipleInheritance = true;
        
        public static bool VirtualInheritance = true;
        
        public static bool SortInheritanceByFile = true;
        
        public string Name { get; private set; }
        
        public DcFile File { get; private set; }
        
        public bool IsStruct { get; set; }
        
        public bool Bogus { get; set; }
        
        public int Number { get; set; }

        public DcField? Constructor { get; private set; }
        
        private List<DcClass> _parents;
        private List<DcField> _fields;
        private List<DcField> _inheritedFields;
        private Dictionary<string, DcField> _fieldsByName;
        private Dictionary<int, DcField> _fieldsByIndex;

        public int NumFields => _fields.Count;

        public DcClass(DcFile dcFile, string name, bool isStruct, bool isBogus)
        {
            File = dcFile;
            Name = name;
            IsStruct = isStruct;
            Bogus = isBogus;
            Number = -1;

            _parents = new List<DcClass>();
            _fields = new List<DcField>();
            _inheritedFields = new List<DcField>();
            _fieldsByName = new Dictionary<string, DcField>();
            _fieldsByIndex = new Dictionary<int, DcField>();
        }
        
        public int NumInheritedFields
        {
            get
            {
                if (MultipleInheritance && VirtualInheritance)
                {
                    File?.CheckInheritedFields();
                    if (_inheritedFields.Count == 0)
                        RebuildInheritedFields();
                    return _inheritedFields.Count;
                }
                else
                {
                    var numFields = NumFields;
                    foreach (var parent in _parents)
                        numFields += parent.NumInheritedFields;
                    return numFields;
                }
            }
        }
        
        public bool AddField(DcField field)
        {
            if (field.Class != null && field.Class != this)
                return false;

            field.Class = this;
            File?.MarkInheritedFieldsStale();
            
            if (field.Name != string.Empty)
            {
                if (field.Name == Name)
                {
                    // The field is a constructor
                    if (Constructor != null)
                        return false;

                    // Constructor must be atomic
                    if (!(field is DcAtomicField)) 
                        return false;
                    
                    Constructor = field;
                    _fieldsByName[field.Name] = field;
                    return true;
                }

                if (!_fieldsByName.TryAdd(field.Name, field))
                    return false;
            }

            if ((VirtualInheritance && SortInheritanceByFile) || !IsStruct)
            {
                if (MultipleInheritance && File != null)
                    File.SetNewIndexNumber(field);
                else
                    field.Number = NumInheritedFields;

                _fieldsByIndex[field.Number] = field;
            }

            _fields.Add(field);
            return true;
        }

        internal void AddParent(DcClass parent)
        {
            _parents.Add(parent);
            File.MarkInheritedFieldsStale();
        }

        internal void RebuildInheritedFields()
        {
            _inheritedFields.Clear();

            var names = new HashSet<string>();
            
            foreach (var parent in _parents)
            {
                var numInheritedFields = parent.NumInheritedFields;
                for (var i = 0; i < numInheritedFields; i++)
                {
                    var field = parent.GetInheritedField(i);
                    if (field.Name == string.Empty)
                    {
                        // Unnamed fields are always inherited
                        if (!SortInheritanceByFile)
                            _inheritedFields.Add(field);
                    }
                    else
                    {
                        if (names.Add(field.Name))
                            _inheritedFields.Add(field);
                    }
                }
            }

            foreach (var field in _fields)
            {
                if (field.Name == string.Empty)
                    _inheritedFields.Add(field);
                else
                {
                    if (!names.Add(field.Name))
                        ShadowInheritedField(field.Name);
                    _inheritedFields.Add(field);
                }
            }
            
            _inheritedFields.Sort((a, b) => a.Number < b.Number ? -1 : 1);
            
        }

        internal void ClearInheritedFields()
        {
            _inheritedFields.Clear(); // TODO: Check integrity of method
        }

        private void ShadowInheritedField(string name)
        {
            for (var i = 0; i < _inheritedFields.Count; i++)
            {
                if (_inheritedFields[i].Name != name) 
                    continue;
                
                _inheritedFields.RemoveAt(i);
                return;
            }
        }

        public DcField? GetField(int n)
        {
            if (n < 0 || n >= _fields.Count)
                return null;
            
            return _fields[n];
        }

        public bool TryGetField(int n, out DcField field)
        {
            field = GetField(n);
            return field != null;
        }

        public DcField? GetFieldByName(string name)
        {
            if (_fieldsByName.TryGetValue(name, out var field))
                return field;
            
            foreach (var parent in _parents)
                if (parent.TryGetFieldByName(name, out field))
                    return field;

            return null;
        }

        public bool TryGetFieldByName(string name, out DcField field)
        {
            field = GetFieldByName(name);
            return field != null;
        }

        public DcField? GetFieldByIndex(int index)
        {
            if (_fieldsByIndex.TryGetValue(index, out var field))
                return field;

            foreach (var parent in _parents)
            {
                if (parent.TryGetFieldByIndex(index, out field))
                {
                    _fieldsByIndex[index] = field;
                    return field;
                }
            }

            return null;
        }

        public bool TryGetFieldByIndex(int index, out DcField field)
        {
            field = GetFieldByIndex(index);
            return field != null;
        }

        public DcField? GetInheritedField(int n)
        {
            if (MultipleInheritance && VirtualInheritance)
            {
                File?.CheckInheritedFields();
                if (_inheritedFields.Count == 0)
                    RebuildInheritedFields();
                return _inheritedFields[n];
            }
            else
            {
                foreach (var parent in _parents)
                {
                    var psize = parent.NumInheritedFields;
                    if (n < psize)
                        return parent.GetInheritedField(n);
                    n -= psize;
                }

                return GetField(n);
            }
        }

        public bool TryGetInheritedField(int n, out DcField field)
        {
            field = GetInheritedField(n);
            return field != null;
        }

        public override string ToString()
        {
            string parents;
            if (_parents.Count > 0)
                parents = " : " + string.Join(", ", _parents.Select(x => x.Name));
            else
                parents = "";
            
            string str;
            if (IsStruct)
                str = $"struct {Name} {{\n";
            else
                str = $"dclass {Name}{parents} {{\n";
            
            foreach (var field in _fields)
                str += $"    {field.ToString()};\n";
            
            str += "};";
            return str;
        }
    }
}