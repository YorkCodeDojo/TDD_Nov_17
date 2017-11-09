using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using words;
using System.Collections.Generic;
using System.Linq;

namespace WordTests
{
    [TestClass]
    public class WordComparison
    {
        // lard -> bard -> bare
        static List<string> TestWords = new List<string>(){ "lard", "bard", "bare", "butter", "farm" };

        [TestMethod]
        public void TwoWordsDiffer()
        {
            Assert.AreNotEqual(words.Program.CompareWords("foo", "bar"), 0 );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "A userId of null was inappropriately allowed.")]
        public void WordLengthsHaveToMatch()
        {
            int val = words.Program.CompareWords("hello", "go");
        }

        [TestMethod]
        public void FoundSingleDistanceWords()
        {

            var ret = words.Program.FindSingleDistanceWords("card", TestWords);
            Assert.AreNotEqual(ret.Count, 0);
            Assert.AreEqual(ret.Count, 2);
            Assert.AreEqual(ret[0], "lard");
            Assert.AreEqual(ret[1], "bard");
        }

        [TestMethod]
        public void FindTargetWordGivenSourceList()
        {
            var list = new List<string>() { "lard", "bard", "bare" };

            var emptyList = new HashSet<string>();
            var ret = words.Program.FindClosestStringToTargetWord("bare", list, emptyList);
            Assert.AreEqual("bare", ret);

            ret = words.Program.FindClosestStringToTargetWord("rare", list, emptyList);
            Assert.AreEqual("bare", ret);
        }

        [TestMethod]
        public void CanFindWordChain()
        {
            var wordList = new List<string> { "lard", "bard", "bare", "care" };
            var chain = words.Program.FindWordChain("lard", "care", wordList);
            Assert.IsTrue(chain.SequenceEqual(wordList));

            chain = words.Program.FindWordChain("bard", "care", wordList);
            Assert.IsTrue(chain.SequenceEqual(new List<string>() { "bard", "bare", "care" }));
        }
    }
}
