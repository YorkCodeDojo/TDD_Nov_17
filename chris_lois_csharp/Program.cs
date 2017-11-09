using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace words
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var wordFile = File.ReadAllLines("Words.txt");
            var words = new List<string>(wordFile);

            while (true)
            {
                System.Console.WriteLine("Word1?");
                var word = System.Console.ReadLine();
                if (word == "quit")
                    break;

                System.Console.WriteLine("Word2?");
                var word2 = System.Console.ReadLine();

                try
                {
                    System.Console.WriteLine(string.Join(",", FindWordChain(word, word2, words).ToArray()));
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }

        public static int CompareWords(string first, string second)
        {
            int n = 0;

            if (first.Length != second.Length)
            {
                throw new ArgumentException("Strings must be equal in length");
            }
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    n += 1;
                }

            }
            return n;
        }

        public static List<string> FindSingleDistanceWords(string testWord, List<string> TestWords)
        {
            var returnWords = new List<string>();

            for (int i = 0; i < TestWords.Count; i++)
            {
                if (testWord.Length == TestWords[i].Length &&
                    CompareWords(testWord, TestWords[i]) == 1)
                {
                    returnWords.Add(TestWords[i]);
                }
            }

            return returnWords;
        }

        public static string FindClosestStringToTargetWord(string targetWord, List<string> sourceWords, HashSet<string> ignoreWords)
        {
            String closestString = string.Empty;
            int closestDistance = targetWord.Length + 1;
            for (int i = 0; i < sourceWords.Count; i++)
            {
                if (targetWord.Length == sourceWords[i].Length)
                {
                    if (ignoreWords.Contains(sourceWords[i]))
                        continue;
                    int thisDistance = CompareWords(targetWord, sourceWords[i]);
                    if (thisDistance < closestDistance)
                    {
                        closestString = sourceWords[i];
                        closestDistance = thisDistance;
                    }
                }
            }
            return closestString;
        }

        public static List<string> FindWordChain(string start, string end, List<string> wordList)
        {
            if (start.Length != end.Length)
                throw new ArgumentException("Strings must be same length");

            var chain = new List<string>();
            var visited = new HashSet<string>() { start };
            string currentWord = start;

            while (currentWord != end)
            {
                chain.Add(currentWord);
                var words = FindSingleDistanceWords(currentWord, wordList);
                currentWord = FindClosestStringToTargetWord(end, words, visited);
                if (string.IsNullOrEmpty(currentWord))
                {
                    chain.Add("<No word found!>");
                    return chain;
                }
                visited.Add(currentWord);

            }
            chain.Add(currentWord);
            return chain;
        }
    }
}