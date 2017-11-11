package co.jfactory.yorktdd

import org.hamcrest.CoreMatchers.*
import org.hamcrest.MatcherAssert.assertThat
import org.hamcrest.core.IsEqual.equalTo

import org.junit.Test

class WordTest {

    val words = Dictionary(listOf("dig", "cat", "cot", "cog", "kit", "dog", "dug", "dot", "hit", "hot", "hog"))
    val wordsFilePath = "/Users/andybowes/dev/abowes/TDD_Nov_17/Words.txt"
    val dictionary = Dictionary(wordsFilePath)

    @Test fun `Given "dog" When Look for close words Then result includes "dig"`(){
        val closeWords = words.generateWords("dog")
        assertThat(closeWords, hasItem("dig"))
    }

    @Test fun `Given "dog" When Look for close words Then result includes "dug"`(){
        val closeWords = words.generateWords( "dog")
        assertThat(closeWords, hasItem("dug"))
    }

    @Test fun `Given "dog" When Look for close words Then result should not include "cat"`(){
        val closeWords = words.generateWords( "dog")
        assertThat(closeWords, not(hasItem("cat")))
    }

    @Test fun `Given "dog" When Look for close words Then result should contain all of "dig", "dug"`(){
        val closeWords = words.generateWords( "dog")
        assertThat(closeWords.containsAll(listOf("dig", "dug")), equalTo(true))
    }

    @Test fun `Given "dog" When Look for close words Then result should not contain all of "cat", "cot", "kit", "dog"`(){
        val closeWords = words.generateWords( "dog")
        val excludedWords = listOf("cat", "cot", "kit", "dog")
        assertThat( closeWords.filter { it in  excludedWords}.size, equalTo(0))
    }

    @Test fun `Given a start word of "dot" then I can get to "cog" in 3 steps`(){
        val steps = findSteps("dot","cog", words)
        assertThat(steps, notNullValue())
        assertThat(steps?.size, equalTo(3))
        assertThat(steps?.first(), equalTo("dot"))
        assertThat(steps?.last(), equalTo("cog"))
        assertThat(steps?.get(1) in listOf("dog", "cot"), equalTo(true))
    }

    @Test fun `Given a start word of "kit" then I can get to "cog" in 5 steps`(){
        val steps = findSteps("kit","cog", words)
        assertThat(steps, notNullValue())
        assertThat(steps?.size, equalTo(5))
        assertThat(steps?.first(), equalTo("kit"))
        assertThat(steps?.last(), equalTo("cog"))
        assertThat(steps?.get(1), equalTo("hit"))
        assertThat(steps?.get(2), equalTo("hot"))
        assertThat(steps?.get(3) in listOf("hog", "cot"), equalTo(true))
    }

    @Test fun `Given a Words file when I read it then it returns a list of words`(){
        assertThat(dictionary.words.size, equalTo(338884))
    }

    @Test fun `Given a start of "cog" When we generate words Then should contain expected words`(){
        val generatedWords = dictionary.generateWords("cog")
        assertThat(generatedWords.containsAll(listOf("cot", "dog", "hog")), equalTo(true) )
        assertThat(generatedWords.none { it in listOf("cat", "cog", "hit") }, equalTo(true) )
    }

    @Test fun `Given a start of "house" When we use a finish of "drink" Then should generate a valid path`(){
        val steps = findSteps("hammer","calmer", dictionary)
        assertThat(steps, notNullValue())
        println(steps?.joinToString(separator = "->"))
        assertThat(steps?.size, equalTo(9))
        assertThat(steps?.first(), equalTo("kit"))
        assertThat(steps?.last(), equalTo("cog"))
        assertThat(steps?.get(1), equalTo("hit"))
        assertThat(steps?.get(2), equalTo("hot"))
        assertThat(steps?.get(3) in listOf("hog", "cot"), equalTo(true))
    }
}
