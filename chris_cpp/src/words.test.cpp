#include <gtest/gtest.h>
#include "words.h"

using namespace std;
TEST(WordDifference, WordComparisons)
{
    ASSERT_EQ(HammingDistance("dog", "cat"), 3);
    ASSERT_EQ(HammingDistance("dog", "bog"), 1);
    ASSERT_EQ(HammingDistance("dog", "dog"), 0);
}

TEST(WordDiffference, FindNearWords)
{
    vector<string> words{ "dog", "bog", "log", "poo", "bar", "foo" };
    std::set<string> str;
    ASSERT_EQ(FindCloseWords("dog", words).size(), 2);
    ASSERT_EQ(FindCloseWords("poo", words).size(), 1);
    ASSERT_EQ(FindCloseWords("bar", words).size(), 0);
}
