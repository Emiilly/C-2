using System;
using UnityEngine;

namespace Assets.Script
{
    /// <summary>
    /// Main class for holding the words, in the future, will have word objects
    /// </summary>
    public class Words
    {
        /// <summary>
        /// game state enum for cycling the words
        /// </summary>
        private enum wordstates
        { easy, medium, hard, test };

        private static wordstates currentstate = wordstates.easy;  //defaults to easy

        /// <summary>
        /// int that logs the current word selection
        /// </summary>
        private int currentselection = 0;

        /// <summary>
        /// int that logs the position of the current word being spelt
        /// defaults to 0
        /// </summary>
        private int spellingpos = 0;

        private bool first_selection = true;
        private static string[] easyWords = { "BALL", "BARK", "COIN", "FUEL" };
        private static string[] mediumWords = { "BEARD", "BRAKE", "COINAGE", "REDGUARD" };
        private static string[] hardWords = { "CRUCIBLE", "AIRPLANE", "MISERABLE", "DISGUSTING" }; //jetfuel cant melt steelbeams #bushdid911

        private static Word[] dummyWords = { new Word("BALL"), new Word("BARK"), new Word("COIN"), new Word("FUEL") };

        public Words()
        {
           //initializing because too dumb to set up first selection
            string dummy=this.getNextWord();

        }

        /// <summary>
        /// advances the spelling pos by 1
        /// currently has NO checks for out of bounds bullshit
        /// </summary>
        public void letterhit()
        {
            this.spellingpos += 1;
        }

        /// <summary>
        /// returns the head of current word
        /// </summary>
        /// <returns></returns>
        public int giveWordHead()
        {
            return this.spellingpos;
        }

        /// <summary>
        /// shuffles down one in the array
        /// </summary>
        /// <returns></returns>
        public string getNextWord()
        {
            //easyword next
            if (currentstate == wordstates.easy)
            {
                if (first_selection == true)
                {
                    first_selection = false;
                    return easyWords[0];
                }
                else
                {
                    if (currentselection + 1 < easyWords.Length )  //may need to check if it's based on 0 or not
                    {
                        currentselection++;
                        this.spellingpos = 0;
                        return easyWords[currentselection];
                    }
                    else
                    {
                        Application.LoadLevel(5);
                    }
                }
            }

            //mediumword next
            if (first_selection == true)
            {
                first_selection = false;
                return mediumWords[0];
            }
            else
            {
                if (currentstate == wordstates.medium)
                {
                    if (currentselection + 1 <= mediumWords.Length - 1)
                    {
                        currentselection++;
                        this.spellingpos = 0;

                        return mediumWords[currentselection];
                    }
                    else
                    {
                        Application.LoadLevel(5);
                    }
                }
            }

            //hardword next
            if (first_selection == true)
            {
                first_selection = false;
                return hardWords[0];
            }
            else
            {
                if (currentstate == wordstates.hard)
                {
                    if (currentselection + 1 <= hardWords.Length - 1)
                    {
                        currentselection++;
                        this.spellingpos = 0;

                        return hardWords[currentselection];
                    }
                    else
                    {
                        Application.LoadLevel(5);
                    }
                }
            }
            if (currentstate == wordstates.test)
            {
                if (first_selection == true)
                {
                    first_selection = false;
                    return dummyWords[0].giveSelf();
                }
                else
                {
                    if (currentselection + 1 <= easyWords.Length - 1)  //may need to check if it's based on 0 or not
                    {
                        this.currentselection++;
                        this.spellingpos = 0;
                        return dummyWords[currentselection].giveSelf();
                    }
                    else
                    {
                        reset();
                        return dummyWords[currentselection].giveSelf();
                    }
                }
            }

            return "NAN";
        }
        /// <summary>
        /// gets the size of the current array
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            if(currentstate==wordstates.easy)
            {
                return easyWords.Length;
            }
            if (currentstate == wordstates.medium)
            {
                return mediumWords.Length;
            }
            if (currentstate == wordstates.easy)
            {
                return hardWords.Length;
            }
            return 0;

        }

        public void reset()
        {
            first_selection = true;
            currentselection = 0;
            this.spellingpos = 0;
        }

        public string giveCurrent()
        {
            //easyword next
            if (currentstate == wordstates.easy)
            {
                return easyWords[currentselection];
            }
            if (currentstate == wordstates.medium)
            {
                return mediumWords[currentselection];
            }
            if (currentstate == wordstates.hard)
            {
                return hardWords[currentselection];
            }

            return "error, no state set";
        }

        /// <summary>
        /// sets the level of the game using a string input
        /// </summary>
        /// <param name="input"></param>
        public static void setLevel(string input)
        {
            foreach (wordstates x in Enum.GetValues(typeof(wordstates)))
            {
                if (input == x.ToString())
                {
                    currentstate = x;
                }
            }
        }
    }
}