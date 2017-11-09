using System;
using System.Collections.Generic;

namespace WordChains
{
    public class Chains
    {
        public HashSet<string> Dictionary { get; set; }

        public Chains()
        {
            this.Dictionary = new HashSet<string>();
        }
        public string Create(string startWord, string endWord)
        {
            if (startWord == endWord) return startWord;

            var maxLevel = 1;
            var result = "";
            while (result == "")
            {
                result = NextLevel(startWord, "", endWord, 0, maxLevel, -1);
                maxLevel++;
            }

            return result;
        }

        private string NextLevel(string word, string path, string endWord, int level, int MaxLevel, int lastPosition)
        {
            if (level >= MaxLevel) return "";

            var newPath = (path == "") ? word : $"{path}->{word}";
            var words = PossibleWords(newPath, word, lastPosition);
            foreach (var newWord in words)
            {
                if (newWord.Item2 == endWord)
                {
                    // We are done
                    return $"{newPath}->{endWord}";
                }
                else
                {
                    var result = NextLevel(newWord.Item2, newPath, endWord, level + 1, MaxLevel, newWord.Item1);
                    if (result != "") return result;
                }
            }

            return "";
        }

        private List<Tuple<int, string>> PossibleWords(string path, string baseWord, int lastPosition)
        {
            var result = new List<Tuple<int, string>>();

            for (int i = 0; i < baseWord.Length; i++)
            {
                if (i != lastPosition)
                {
                    var letters = baseWord.ToCharArray();
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        letters[i] = c;
                        var newWord = string.Join("", letters);
                        if (this.Dictionary.Contains(newWord) && !path.Contains(newWord))
                        {
                            result.Add(new Tuple<int, string>(i, newWord));
                        }
                    }
                }
            }

            return result;
        }
    }
}
