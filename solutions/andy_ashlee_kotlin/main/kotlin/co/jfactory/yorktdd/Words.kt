package co.jfactory.yorktdd

import java.io.FileInputStream
import java.util.PriorityQueue

fun hammingDistance(word1: String, word2: String) = word2.zip(word2).map { if (it.first == it.second) 0 else 1 }.sum()

class Dictionary(val words: List<String>) {

    constructor(filePath: String) : this(FileInputStream(filePath).bufferedReader().readLines())

    private val knownNeighbours = mutableMapOf<String, List<String>>()  // Remember neighbors of previously seen words

    fun generateWords(word: String) = when (word) {
        in knownNeighbours -> emptyList()  // If we have already seen this word then assume that the previous option was shorter
        else -> knownNeighbours.getOrPut(word, {
            (0 until word.length).map { i -> ('a'..'z').map { c -> word.replaceRange(i, i + 1, c.toString()) } }
            .flatten()
            .filter { it in words && it != word }
        })
    }
}

class QueueEntry(val previousWords: List<String>, val distance: Int) : Comparable<QueueEntry> {
    override fun compareTo(other: QueueEntry) = when {
        distance < other.distance -> -1
        distance > other.distance -> 1
        else -> previousWords.size.compareTo(other.previousWords.size)
    }
}

fun findSteps(start: String, finish: String, dictionary: Dictionary): List<String> {
    val subDictionary = Dictionary(dictionary.words.filter { it.length == start.length })
    val queue = PriorityQueue<QueueEntry>()
    queue.add(QueueEntry(listOf(start), hammingDistance(start, finish)))
    while (queue.isNotEmpty()) {
        val previousWords = queue.remove().previousWords
        val nextWords = subDictionary.generateWords(previousWords.last()).filterNot { it in previousWords }
        if (nextWords.contains(finish)) {
            return previousWords.plus(finish)
        }
        nextWords.forEach { word -> queue.add(QueueEntry(previousWords.plus(word), hammingDistance(start, finish))) }
    }
    return emptyList()
}
