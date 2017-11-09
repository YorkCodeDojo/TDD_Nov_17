#include <cstdio>
#include <cstdlib>
#include <iostream>
#include <fstream>
#include <iterator>
#include <vector>
#include <string>
#include <sstream>
#include <algorithm>
#include <string>
#include "src/words.h"

using namespace std;

std::string ToLower(std::string& str)
{
    std::string ret = str;
    std::transform(ret.begin(), ret.end(), ret.begin(), ::tolower);
    return ret;
}
int main(int, char**)
{
    vector<string> words(istream_iterator<string>(ifstream("Words.txt")), istream_iterator<string>());
    for (auto& w : words)
    {
        w = ToLower(w);
    }
    if (words.empty())
    {
        std::cout << "!!Words not found - in directory?" << std::endl;
    }

    while (true)
    {
        std::string word1;
        std::string word2;
        std::cout << "Enter a word!" << std::endl;
        std::cin >> word1;
        std::cin >> word2;
        auto ret = FindSteps(word1, word2, words);
        std::ostringstream strOut;
        for (auto& s : ret)
        {
            strOut << s << "->";
        }
        std::cout << strOut.str() << std::endl;
    }
    return 0;
}
