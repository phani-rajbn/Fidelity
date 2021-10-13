using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleMvcApp.Models
{
    public class Assignment
    {
        const string BASE ="the quick and brown fox jumps over lazy dog";
        public string getEncodedValue(string content)
        {
            string res = "";
            foreach(var ch in content)
            {
                res += getEncodedChar(ch).ToString() + " ";
            }
            return res;
        }

        private int getEncodedChar(char ch)
        {
            string value = "";
            var words = BASE.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(ch))
                {
                    value = i.ToString();
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if(words[i][j] == ch)
                        {
                            value += j.ToString();
                        }
                    }
                }
            }
            return int.Parse(value);
        }
    }
}