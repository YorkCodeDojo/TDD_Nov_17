using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordChains
{
    public class BreadthChains
    {
        public HashSet<string> UsedWords { get; set; }
        public HashSet<string> Dictionary { get; set; }

        public BreadthChains()
        {
            this.Dictionary = new HashSet<string>();
            
        }
        public string Create(string startWord, string endWord)
        {
            if (startWord == endWord) return startWord;

            this.UsedWords = new HashSet<string>();

            var queue = new Queue<QueuedPath>();
            queue.Enqueue(new QueuedPath() { LastChanged = -1, Path = "", Word = startWord });
            this.UsedWords.Add(startWord);

            while (queue.Count > 0)
            {
                var previousWords = queue.Dequeue();
                var possibleWords = PossibleWords(previousWords.Path, previousWords.Word, previousWords.LastChanged);

                foreach (var possibleWord in possibleWords)
                {
                    if (possibleWord.Item2 == endWord)
                    {
                        // We are done
                        var result =  previousWords.Path + "->" + previousWords.Word + "->" + endWord;
                        if (result.StartsWith("->")) result = result.Substring("->".Length);
                        return result;
                    }

                    var newEntry = new QueuedPath()
                    {
                        LastChanged = possibleWord.Item1,
                        Word = possibleWord.Item2,
                        Path = previousWords.Path + "->" + previousWords.Word
                    };
                    queue.Enqueue(newEntry);

                    this.UsedWords.Add(possibleWord.Item2);
                }
            }

            return "";
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
                            if (this.Dictionary.Contains(newWord) && !this.UsedWords.Contains(newWord))
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

        private class QueuedPath
        {
            public string Path { get; set; }
            public string Word { get; set; }
            public int LastChanged { get; set; }
        }
    }
}
