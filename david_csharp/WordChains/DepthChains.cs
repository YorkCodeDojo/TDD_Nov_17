using System;
using System.Collections.Generic;

namespace WordChains
{
    public class DepthChains
    {
        public HashSet<string> Dictionary { get; set; }

        public DepthChains()
        {
            this.Dictionary = new HashSet<string>();
        }
        public string Create(string startWord, string endWord)
        {
            var numberOfDifferentLetters = CountNumberOfDifferentLetters(startWord, endWord);
            if (numberOfDifferentLetters == 0) return startWord;

            var maxLevel = numberOfDifferentLetters - 1;
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
                    if (level + 1 < MaxLevel)
                    {
                        var result = NextLevel(newWord.Item2, newPath, endWord, level + 1, MaxLevel, newWord.Item1);
                        if (result != "") return result;
                    }
                }
            }

            return "";
        }

        private static int CountNumberOfDifferentLetters(string startWord, string endWord)
        {
            var numberDifferent = 0;
            for (int i = 0; i < startWord.Length; i++)
            {
                if (startWord[i] != endWord[i]) numberDifferent++;
            }
            return numberDifferent;
        }

        private List<Tuple<int, string>> PossibleWords(string path, string baseWord, int lastPosition)
        {
            var result = new List<Tuple<int, string>>();

            var letters = baseWord.ToCharArray();
            for (int i = 0; i < baseWord.Length; i++)
            {
                if (i != lastPosition)
                {
                    var original = letters[i];
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        if (c != original)
                        {
                            letters[i] = c;
                            var newWord = new string(letters);
                            if (this.Dictionary.Contains(newWord) && !path.Contains(newWord))
                            {
                                result.Add(new Tuple<int, string>(i, newWord));
                            }
                        }
                    }
                    letters[i] = original;
                }
            }

            return result;
        }
    }
}
