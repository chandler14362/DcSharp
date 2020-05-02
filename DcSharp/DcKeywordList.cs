using System.Collections.Generic;

namespace DcSharp
{
    public class DcKeywordList
    {
        public List<DcKeyword> Keywords { get; private set; }
        
        public Dictionary<string, DcKeyword> KeywordsByName { get; private set; }

        public int Flags { get; private set; }
        
        public DcKeywordList()
        {
            Keywords = new List<DcKeyword>();
            KeywordsByName = new Dictionary<string, DcKeyword>();
            Flags = 0;
        }

        public DcKeywordList(DcKeywordList other)
        {
            Keywords = new List<DcKeyword>(other.Keywords);
            KeywordsByName = new Dictionary<string, DcKeyword>(other.KeywordsByName);
            Flags = other.Flags;
        }
        
        public bool HasKeyword(string name)
        {
            return KeywordsByName.ContainsKey(name);
        }

        public bool HasKeyword(DcKeyword keyword)
        {
            return Keywords.Contains(keyword);
        }

        public int GetNumKeywords()
        {
            return Keywords.Count;
        }

        public DcKeyword GetKeyword(int n)
        {
            return Keywords[n];
        }

        public DcKeyword GetKeywordByName(string name)
        {
            return KeywordsByName[name];
        }

        public bool TryGetKeyword(string name, out DcKeyword keyword)
        {
            return KeywordsByName.TryGetValue(name, out keyword);
        }
        
        public bool AddKeyword(DcKeyword keyword)
        {
            if (!KeywordsByName.TryAdd(keyword.Name, keyword))
                return false;

            Keywords.Add(keyword);
            Flags |= keyword.HistoricalFlag;
            return true;
        }

        public void ClearKeywords()
        {
            Keywords.Clear();
            KeywordsByName.Clear();
            Flags = 0;
        }
    }
}