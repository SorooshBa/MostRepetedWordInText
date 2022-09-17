using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepetedWord
{
    public class Word
    {
        public string word;
        public int count = 0;
        public Word(string word)
        {
            this.word = word;
            count++;
        }
    }
}
