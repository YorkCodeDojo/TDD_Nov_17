#pragma once
#include <string>
#include <algorithm>
#include <numeric>
#include <queue>
#include <vector>
#include <set>

int HammingDistance(const std::string& word1, const std::string& word2);
std::vector<std::string> FindCloseWords(const std::string& word, const std::vector<std::string>& words);
std::vector<std::string> FindSteps(const std::string& start, const std::string& finish, const std::vector<std::string>& words);
