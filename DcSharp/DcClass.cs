using System.Collections.Generic;
using System.Linq;

namespace DcSharp
{
    public class DcClass : DcDeclaration
    {
        public static bool MultipleInheritance = true;
        
        public static bool VirtualInheritance = true;
        
        public static bool SortInheritanceByFile = true;
        
        /// <value>
        /// The name of the <c>DcClass</c>
        /// </value>
        public string Name { get; private set; }
        
        /// <value>
        /// The <c>DcFile</c> defining the <c>DcClass</c>
        /// </value>
        public DcFile? File { get; private set; }
        
        /// <value>
        /// A flag indicating if the <c>DcClass</c> is a struct or not.
        /// </value>
        public bool IsStruct { get; set; }
        
        /// <value>
        /// A flag indicating if the <c>DcClass</c> is bogus or not.
        /// </value>
        public bool Bogus { get; set; }
        
        /// <value>
        /// The <c>DcClass</c> number.
        /// </value>
        public int Number { get; set; }

        /// <value>
        /// The <c>DcClass</c> constructor.
        /// </value>
        public DcField? Constructor { get; private set; }
        
        private List<DcClass> _parents;
        private List<DcField> _fields;
        private List<DcField> _inheritedFields;
        private Dictionary<string, DcField> _fieldsByName;
        private Dictionary<int, DcField> _fieldsByIndex;

        /// <value>
        /// The number of fields defined inside the <c>DcClass</c>
        /// </value>
        public int NumFields => _fields.Count;

        /// <value>
        /// The number of inherited fields inside the DcClass
        /// </value>
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
        
        public DcClass(DcFile? dcFile, string name, bool isStruct, bool isBogus)
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

        /// <summary>
        /// Adds a field to the <c>DcClass</c>
        /// </summary>
        /// <param name="field">The field to add</param>
        /// <returns>True on success, false on error</returns>
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

        /// <summary>
        /// Adds a parent <c>DcClass</c> to the <c>DcClass</c>
        /// </summary>
        /// <param name="parent">The parent</param>
        public void AddParent(DcClass parent)
        {
            _parents.Add(parent);
            File?.MarkInheritedFieldsStale();
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
            
            _inheritedFields.Sort((a, b) => a.Number > b.Number ? 1 : -1);
            
        }

        internal void ClearInheritedFields()
        {
            _inheritedFields.Clear();
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

        /// <summary>
        /// Gets the nth field defined inside the <c>DcClass</c>
        /// </summary>
        /// <param name="n">The field index</param>
        /// <returns>The field or null</returns>
        public DcField? GetField(int n)
        {
            if (n < 0 || n >= _fields.Count)
                return null;
            
            return _fields[n];
        }

        /// <summary>
        /// Tries to get the nth field defined inside the <c>DcClass</c>
        /// </summary>
        /// <param name="n">THe field index</param>
        /// <param name="field">The field</param>
        /// <returns>True on success, false on error</returns>
        public bool TryGetField(int n, out DcField field)
        {
            field = GetField(n);
            return field != null;
        }

        /// <summary>
        /// Gets a field by name within the <c>DcClass</c>
        /// </summary>
        /// <param name="name">The name of the field</param>
        /// <returns>The field or null</returns>
        public DcField? GetFieldByName(string name)
        {
            if (_fieldsByName.TryGetValue(name, out var field))
                return field;
            
            foreach (var parent in _parents)
                if (parent.TryGetFieldByName(name, out field))
                    return field;

            return null;
        }

        /// <summary>
        /// Tries to get a field by name within the <c>DcClass</c>
        /// </summary>
        /// <param name="name">The name of the field</param>
        /// <param name="field">The field</param>
        /// <returns>True on success, false on error</returns>
        public bool TryGetFieldByName(string name, out DcField field)
        {
            field = GetFieldByName(name);
            return field != null;
        }

        /// <summary>
        /// Gets a field by global index inside the <c>DcClass</c>
        /// </summary>
        /// <param name="index">The index of the field</param>
        /// <returns>The field or null</returns>
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

        /// <summary>
        /// Tries to get a field with a given index inside the <c>DcClass</c>
        /// </summary>
        /// <param name="index">The field index</param>
        /// <param name="field">The field</param>
        /// <returns>True on success, false on error</returns>
        public bool TryGetFieldByIndex(int index, out DcField field)
        {
            field = GetFieldByIndex(index);
            return field != null;
        }

        /// <summary>
        /// Gets the nth inherited field.
        /// </summary>
        /// <param name="n">The inherited field index</param>
        /// <returns>The inherited field or null</returns>
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

        /// <summary>
        /// Tries to get the nth inherited field.
        /// </summary>
        /// <param name="n">The inherited field index</param>
        /// <param name="field"></param>
        /// <returns>True on success, false on error</returns>
        public bool TryGetInheritedField(int n, out DcField field)
        {
            field = GetInheritedField(n);
            return field != null;
        }

        /// <summary>
        /// Gets the index of an inherited field
        /// </summary>
        /// <param name="field">The field</param>
        /// <returns>The field index or -1</returns>
        public int GetInheritedFieldIndex(DcField field)
        {
            if (!_inheritedFields.Contains(field))
                return -1;
            
            return _inheritedFields.IndexOf(field);
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