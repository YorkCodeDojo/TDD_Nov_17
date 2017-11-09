package co.jfactory.yorktdd

import org.hamcrest.CoreMatchers.*
import org.hamcrest.MatcherAssert.assertThat
import org.hamcrest.core.IsEqual.equalTo

import org.junit.Test

class WordTest {

    val words = listOf("dig", "cat", "cot", "cog", "kit", "dog", "dug", "dot", "hit", "hot", "hog")

    @Test fun `Given "dog" When Look for close words Then result includes "dig"`(){
        val closeWords = findCloseWords( "dog", words)
        assertThat(closeWords, hasItem("dig"))
    }

    @Test fun `Given "dog" When Look for close words Then result includes "dug"`(){
        val closeWords = findCloseWords( "dog", words)
        assertThat(closeWords, hasItem("dug"))
    }

    @Test fun `Given "dog" When Look for close words Then result should not include "cat"`(){
        val closeWords = findCloseWords( "dog", words)
        assertThat(closeWords, not(hasItem("cat")))
    }

    @Test fun `Given "dog" When Look for close words Then result should contain all of "dig", "dug"`(){
        val closeWords = findCloseWords( "dog", words)
        assertThat(closeWords.containsAll(listOf("dig", "dug")), equalTo(true))
    }

    @Test fun `Given "dog" When Look for close words Then result should not contain all of "cat", "cot", "kit", "dog"`(){
        val closeWords = findCloseWords( "dog", words)
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

}

