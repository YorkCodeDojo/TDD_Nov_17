using System.Collections.Generic;
using Xunit;

namespace WordChains.Tests
{
    public class ChainTests
    {
        [Theory]
        [MemberData(nameof(ChainEndsDataSource.TestData), MemberType = typeof(ChainEndsDataSource))]
        public void A_Chain_Should_Begin_With_The_Start_Word(string startWord, string endWord, int a)
        {
            var chain = CreateChain(startWord, endWord);

            var split = chain.Split(new[] { "->" }, System.StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(startWord, split[0]);
        }

        [Theory]
        [MemberData(nameof(ChainEndsDataSource.TestData), MemberType = typeof(ChainEndsDataSource))]
        public void A_Chain_Should_Finish_With_The_End_Word(string startWord, string endWord, int a)
        {
            var chain = CreateChain(startWord, endWord);

            var split = chain.Split(new[] { "->" }, System.StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(endWord, split[split.Length - 1]);
        }

        [Theory]
        [MemberData(nameof(ChainEndsDataSource.TestData), MemberType = typeof(ChainEndsDataSource))]
        public void Only_One_Letter_Should_Change_At_A_Time(string startWord, string endWord, int a)
        {
            var chain = CreateChain(startWord, endWord);

            var split = chain.Split(new[] { "->" }, System.StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < split.Length - 1; i++)
            {
                Assert.Equal(1, CountNumberOfDifferentLetters(split[i], split[i + 1]));
            }
        }

        [Theory]
        [MemberData(nameof(ChainEndsDataSource.TestData), MemberType = typeof(ChainEndsDataSource))]
        public void TheLengthOfTheChainMustBeAtLeastTheNumberOfDifferingLetters(string startWord, string endWord, int numberOfDifferingLetters)
        {
            var chain = CreateChain(startWord, endWord);

            var split = chain.Split(new[] { "->" }, System.StringSplitOptions.RemoveEmptyEntries);

            Assert.True(split.Length >= numberOfDifferingLetters);
        }

        [Theory]
        [MemberData(nameof(ChainEndsDataSource.TestData), MemberType = typeof(ChainEndsDataSource))]
        public void All_Words_In_The_Chain_Must_Be_In_The_Dictionary(string startWord, string endWord, int a)
        {
            var chain = CreateChain(startWord, endWord);

            var split = chain.Split(new[] { "->" }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in split)
            {
                Assert.Contains(word, GetDictionary());
            }
        }

        [Fact]
        public void WrongPath()
        {
            //  AAA => AAC => BAC => BBC => BBE
            //  AAA => AAB

            var chains = new Chains()
            {
                Dictionary = new HashSet<string>() { "AAA", "AAC", "BAC", "BBC", "AAB", "BBE" }
            };
            var chain = chains.Create("AAA", "BBE");

            var split = chain.Split(new[] { "->" }, System.StringSplitOptions.RemoveEmptyEntries);
        }

        private static HashSet<string> GetDictionary() => new HashSet<string>() { "PAT", "PAN", "PIN", "BIN", "CAT", "CAN",
                                                     "AAAA","AABA", "AABC",
                                                     "AAAAA", "AABAA", "AABCA", "AABCD", "AA", "AB", "AAA", "ABC",
                                                     "ABA", "CBA" };
        private static string CreateChain(string startWord, string endWord)
        {
            var chains = new Chains()
            {
                Dictionary = GetDictionary()
            };
            return chains.Create(startWord, endWord);
        }

        public static class ChainEndsDataSource
        {
            private static readonly List<object[]> _data
                = new List<object[]>
                    {
                    new object[] {"CAT", "CAN", 1},
                    new object[] {"AAAA", "AABC", 2},
                    new object[] {"AAAAA", "AABCD", 3},
                    new object[] {"AA", "AA", 0},
                    new object[] {"AA", "AB", 1},
                    new object[] {"AAA", "ABC", 2},
                    new object[] {"AAA", "CBA", 2},
                    };

            public static IEnumerable<object[]> TestData
            {
                get { return _data; }
            }
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
    }
}
