﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1
{
    internal static class CompressingClass
    {
        internal static string CompressString(this string str)
        {
            char previousChar = str[0];
            string compressedStr = "";

            int countChar = 1;

            for (int i = 1; i < str.Length; i++)
            {
                if (previousChar == str[i]) //if the chars are repeats...
                {
                    countChar++;
                }
                else //if not
                {
                    compressedStr += previousChar;

                    if (countChar > 1)
                        compressedStr += countChar;

                    previousChar = str[i];
                    countChar = 1;
                }
            }

            //for last type of the char
            compressedStr += previousChar;
            if (countChar > 1)
            {
                compressedStr += countChar;
            }
            return compressedStr;
        }

        internal static string CompressStringBuilder(this string str)
        {
            char[] delimiters = { ' ', ',', '.', '\n', '\t' };
            string[] words = str.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder compressedStr = new StringBuilder();

            foreach (var word in words)
            {
                char previousChar = '\0';
                int countChar = 1;

                for (int i = 1; i < word.Length; i++)
                {
                    if (word[i] == previousChar)
                    {
                        countChar++;
                    }
                    else
                    {
                        compressedStr.Append(previousChar);

                        if (countChar > 1)
                            compressedStr.Append(countChar);

                        previousChar = word[i];
                        countChar = 1;
                    }
                }

                compressedStr.Append(previousChar);
                if (countChar > 1)
                    compressedStr.Append(countChar);

                compressedStr.Append(' ');
            }
            return compressedStr.ToString().TrimEnd();
        }

        internal static string DecompressString(this string str) 
        {
            string decompressedString = "";

            int charQuantity = 0;
            char previousChar = '\0';

            for (int i = 0; i < str.Length; i++) 
            {
                if (!char.IsDigit(str[i]))
                {
                    decompressedString += str[i];
                }
                else
                {
                    charQuantity = int.Parse(str[i].ToString());

                    for (int j = 0; j < charQuantity-1; j++)
                        {
                            decompressedString += str[i-1];
                        }
                }
                charQuantity = 0;
            }

            return decompressedString;
        }
    }
}
