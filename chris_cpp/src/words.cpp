#include "words.h"
#include <set>
#include <cstdio>
#include <iostream>

using namespace std;


int HammingDistance(const string& word1, const string& word2)
{
    return inner_product(word1.begin(), word1.end(), word2.begin(), 0, std::plus<>(), [](const char& ch1, const char& ch2)
    {
        return (ch1 != ch2) ? 1 : 0;
    });
};

vector<string> FindCloseWords(const string& word, const std::vector<string>& words)
{
    vector<string> ret;
    copy_if(words.begin(), words.end(), back_inserter(ret), [&word](const string& testWord)
    {
        return HammingDistance(word, testWord) == 1;
    });
    return ret;
}

vector<string> FindSteps(const string& start, const string& finish, const std::vector<string>& words)
{
    queue<vector<string>> queue;
    queue.push(vector<string>{start});

    std::vector<std::string> candidates;
    copy_if(words.begin(), words.end(), back_inserter(candidates), [&start](const std::string& w) { return w.length() == start.length(); });

    while (!queue.empty())
    {
        auto previousWords = queue.front();
        queue.pop();

        auto nextWords = FindCloseWords(previousWords.back(), candidates);
        if (std::find(nextWords.begin(), nextWords.end(), finish) != nextWords.end())
        {
            previousWords.push_back(finish);
            return previousWords;
        }

        // append a word to a vector of strings and return a new one
        auto addWord = [](const std::vector<string>& list, const std::string& word)
        {
            std::vector<string> ret(list);
            ret.push_back(word);
            return ret;
        };

        for (auto& next : nextWords)
        {
            if (std::find(previousWords.begin(), previousWords.end(), next) == previousWords.end())
            {
                queue.push(addWord(previousWords, next));
            }
        }
    }
    return std::vector<string>();
}