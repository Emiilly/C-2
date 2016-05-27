using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    public class Words
    {
        static string printedWord = "BALL";

        public Words()
        {

        }

        public string getNext(int next)
        {
            return printedWord[next].ToString();
        }

        
    }
}
