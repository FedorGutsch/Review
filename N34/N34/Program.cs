using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N34
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Write sentence with whitespaces between words and with dot after last word");

                string input = Console.ReadLine();
                CheckSentence(input);

                var result = findDifferentWords(SplitString(input));   //find words which are different to last word in the sentence
                
                Console.WriteLine(Output(result));
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
        
        /// <summary>
        ///     Split the string by whitespaces and dots.
        ///     
        ///     It splits the sentence with built-in function of the class System.String()
        /// </summary>
        /// <param name="s"></param>
        /// <returns> An Array of string without Empty objects </returns>
        static string[] SplitString(string s)
        {
            string[] SplitedString = s.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            return SplitedString;
        }

        
        
        /// <summary>
        ///     Find words, which are different to the last word in the sentence. 
        ///     It goes through every word in the sentence(Array splited by method SplitString()) and compare them with the last word 
        ///     
        ///     if the word are not the same as lastword it Add this word to the List of words different to last word
        /// </summary>
        /// <param name="wordsOfSentence"></param>
        /// <returns> An Array of words different to last word </returns>
        
        static string[] findDifferentWords(string[] wordsOfSentence)
        {
            string lastWord = wordsOfSentence[wordsOfSentence.Length - 1];
     
            List<string> wordsDifferentToLast = new List<string>();
            
            CheckWord(new StringBuilder(lastWord));
            
            for(int i = 0; i < wordsOfSentence.Length-1; i++)
            {
                StringBuilder word = new StringBuilder(wordsOfSentence[i]);
                CheckWord(word);
                
                if (word.ToString() != lastWord)
                {
                    wordsDifferentToLast.Add(removeEveryLastLetter(word));
                } 
            }

            return wordsDifferentToLast.ToArray();
        }

        
        
        /// <summary>
        ///     It goes from one Letter to another in the word and compare it with the last letter in word
        ///     
        ///     It builds new word with letters different to last letter, and if it isnt the same, it Add this Letter to the new word.
        ///     
        ///     After all it adds last Letter of word to the new word
        /// </summary>
        /// <param name="word"></param>
        /// <returns> String without double using last letter </returns>
        
        static string removeEveryLastLetter(StringBuilder word) 
        {
            //StringBuilder wordSB = new StringBuilder(word);
            string transformedWord = string.Empty;
            var lastLetter = word[word.Length - 1];
            
            CheckWord(word);

            
            for (int i = 0; i < word.Length - 1 ; i++)
            {                
                var curLetter = word[i];
                
                if (lastLetter != curLetter)
                {
                    transformedWord += curLetter;
                }
            }
            transformedWord += lastLetter;

            
            return transformedWord;
        }

        
        
        /// <summary>
        ///     It checks length of sentence, and if it isnt allright throws the Exception of Wrong Length of Sentence
        /// </summary>
        /// <param name="temp"></param>
        /// <exception cref="Exception"></exception>
        
        static void CheckSentence(string temp)
        {
            StringBuilder iterableString = new StringBuilder(temp);
            var splitedString = SplitString(temp);
            
            if(splitedString.Length > 30 || splitedString.Length < 2)
            {
                throw new Exception("Wrong Length of Sentence");
            }

            char lastSymbolInString = iterableString[iterableString.Length - 1];

            if (lastSymbolInString != '.')
            {
                throw new Exception("There isn't dot in the end of sentence");
            }
        }

        
        
        /// <summary>
        ///     It Checks length of the word and if it isn't long enough throws exception, 
        ///     which means that one word of the sentence is too short
        /// 
        ///     It goes from one letter to another, and if it isn't english throws Wrong Language exception
        /// </summary>
        /// <param name="word"></param>
        /// <exception cref="Exception"></exception>
        
        static void CheckWord(StringBuilder word)
        {
            if (word.Length > 10 || word.Length < 2)
            {
                throw new Exception("Wrong length of one word in the sentence, change Input sentence");
            }

            for (int i = 0; i < word.Length - 1; i++) 
            {                
                var curLetter = word[i];
                

                if (!(curLetter >= 'A' && curLetter <= 'z'))
                {
                    throw new Exception("Wrong language of word");
                }
            }
        }
        
        
        /// <summary>
        ///    Build new string with elements from array
        /// </summary>
        /// <param name="temp"></param>
        /// <returns> Elements of array in the string </returns>
        static string Output(string[] temp)
        {
            string StringOfArrayElements = string.Empty;
            
            foreach(string elementOfArray in temp)
            {
                StringOfArrayElements = StringOfArrayElements + elementOfArray + ' ';
            }

            return StringOfArrayElements;
        }
    }
}
