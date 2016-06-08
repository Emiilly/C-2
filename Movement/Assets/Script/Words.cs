using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{    public class Words
    {
        /// <summary>
        /// game state enum for cycling the words
        /// </summary>
        enum wordstates { easy, medium, hard, test };
        wordstates currentstate = wordstates.easy;  //defaults to easy

        /// <summary>
        /// int that logs the current word selection
        /// </summary>
        private int currentselection = 0;
        bool first_selection = true;
        static string[] easyWords = { "BALL", "BARK", "COIN", "FUEL" };
        static string[] mediumWords = { "BALL", "BARK", "COIN", "FUEL" };
        static string[] hardWords = { "BALL", "BARK", "COIN", "FUEL" }; //jetfuel cant melt steelbeams #bushdid911

        static Word[] dummyWords = { new Word("BALL"), new Word("BARK"), new Word("COIN"), new Word("FUEL") };

        public Words()
        {

        }

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
                    if (currentselection + 1 <= easyWords.Length - 1)  //may need to check if it's based on 0 or not
                    {
                        currentselection++;
                        return easyWords[currentselection];
                    }
                    else
                    {
                        reset();
                        return easyWords[currentselection];
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
                        return mediumWords[currentselection];
                    }
                    else
                    {
                        reset();
                        return mediumWords[currentselection];
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
                        return hardWords[currentselection];
                    }
                    else
                    {
                        reset();
                        return hardWords[currentselection];
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

        public int Size()
        {
            return easyWords.Length;
        }

        public void reset()
        {
            first_selection = true;
            currentselection = 0;
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
                return easyWords[currentselection];
            }
            if (currentstate == wordstates.hard)
            {
                return easyWords[currentselection];
            }


            return "error, no state set";
        }
    }

}
  


    

