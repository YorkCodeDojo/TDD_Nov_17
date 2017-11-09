package co.jfactory.yorktdd

fun findCloseWords(from: String, words: List<String>) = words.filter { word -> hammingDistance(from, word) == 1 }


private fun hammingDistance(word1: String, word2: String) = when {
    (word1.length != word2.length) -> -1
    else -> word1.zip(word2).map { if (it.first == it.second) 0 else 1 }.sum()
}


fun findSteps(start: String, finish: String, words : List<String>): List<String>? {

    val queue = mutableListOf<List<String>>()
    queue.add(listOf(start))

    while (queue.isNotEmpty()){
        val previousWords = queue.removeAt(0)
        val nextWords = findCloseWords(previousWords.last(), words).


        if (nextWords.contains(finish)){
            return previousWords.addWord(finish)
        }
        nextWords.forEach { word -> queue.add(previousWords.addWord(word)) }
    }
    return null
}

fun List<String>.addWord(word: String) : List<String> {
    val steps = this.toMutableList()
    steps.add(word)
    return steps.toList()
}
