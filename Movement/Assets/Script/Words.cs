using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    public class Words
    {
        static string[] easyWords = { "BALL", "BARK", "COIN", "FUEL" };

        public Words()
        {

        }

        public string getNextWord(int next)
        {
            return easyWords[next];
        }

        public int Size()
        {
            return easyWords.Length;
        }




    }
}
