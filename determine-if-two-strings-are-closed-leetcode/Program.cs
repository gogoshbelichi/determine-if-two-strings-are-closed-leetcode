bool CloseStrings(string word1, string word2) {
        if (word1.Length != word2.Length)
        {
            return false;
        }
        var hs1 = MakeHashMap(word1);
        var sorted1 = hs1.OrderBy(pair => pair.Value);
        var hs2 = MakeHashMap(word2);
        var sorted2 = hs2.OrderBy(pair => pair.Value);
        if (MatchingLetters(hs1, hs2) == true) //&& KeyValuePairMatching(hs1, hs2) == true)
        {
            foreach (var (item1, item2) in sorted1.Zip(sorted2))
            {
                if (item1.Value != item2.Value)
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

Dictionary<char, int> MakeHashMap(string word) {
        var hs = new Dictionary<char, int>();
        foreach (char ch in word)
        {
            if (!hs.ContainsKey(ch))
            {
                hs.Add(ch, 1);
            }
            else
            {
                hs[ch]++;
            }
        }
        return hs;
    }

bool MatchingLetters(Dictionary<char, int> hs1, Dictionary<char, int> hs2) {
        foreach (var kvp in hs1)
        {
            if (!hs2.ContainsKey(kvp.Key) || !hs2.ContainsValue(kvp.Value))
            { 
                return false;
            }
        }
        return true;
        // foreach (var kvp in hs1)
        // {
        //     if (hs2[kvp.Key] != kvp.Value)
        //     { 
        //         return false;
        //     }
        // }
        // return true;
    }

    // private bool KeyValuePairMatching(Dictionary<char, int> hs1, Dictionary<char, int> hs2)
    // {
    //     if (hs1.Count() == hs2.Count())
    //     {
    //         return ValuesMatching(hs1, hs2);
    //     }
    //     return false;
    // }

    // private bool ValuesMatching(Dictionary<char, int> hs1, Dictionary<char, int> hs2)
    // {
    //     if (hs1.Count() == hs2.Count())
    //     {
    //         return ValuesMatching(hs1, hs2);
    //     }
    //     return false;
    // }