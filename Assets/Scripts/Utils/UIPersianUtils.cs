using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace UIPersian.Utils
{
    public static class UIPersianUtils
    {
        /// <summary>
        /// convert text string for To unity display format
        /// </summary>
        /// <param name="text">string to fix</param>
        /// <returns>Persian RTL string for display in Text Component</returns>
        public static string ToPersian(this string text)
        {
            //ﺉﻚﻙﯤ
            //text = text.Replace('ی', 'ﻱ');
            //text = text.Replace( 'ی','ﺉ');
            //text = text.Replace('ک', 'ﻙ');
            //text = text.Replace('ﻚ', 'ک');
            text = ArabicSupport.ArabicFixer.Fix(text, true, false);
            text = text.Replace('ﺃ', 'آ');
            return text;
        }

        /// <summary>
        /// extention for convert text to unity persian format with rich text data Tag 
        /// </summary>
        /// <param name="text">string to fix</param>
        /// <returns>Persian RTL string for display in Text Component</returns>
        public static string ToPersianWithMeta(this string text)
        {
            if (String.IsNullOrEmpty(text))
                return text;
            string textWithMeta = "";
            string[] output = Regex.Split(text, "(?=<)|(?<=>)");


            string onlyperisan = "";
            for (int i = 0; i < output.Length; i++)
            {
                if (!output[i].Contains("<"))
                    onlyperisan += output[i];
            }

            onlyperisan = onlyperisan.ToPersian();
            
            int startIndex = 0;
            int startTagCount = 0;
            int endTagCount = 0;

            for (int i = 0; i < output.Length; i++)
            {
                if (output[i].Contains("</"))
                {
                    endTagCount += 1;
                    int index = onlyperisan.Length - startIndex;
                    var startTag = FindStartTag(output, endTagCount);
                    onlyperisan = onlyperisan.Insert(index, startTag);
                    startIndex += startTag.Length;
                }
                else if (output[i].Contains("<"))
                {
                    startTagCount += 1;
                    int index = onlyperisan.Length - startIndex;
                    var endTag = FindEndTag(output, startTagCount);
                    onlyperisan = onlyperisan.Insert(index, endTag);
                    startIndex += endTag.Length;
                }
                else
                {
                    startIndex += output[i].Length;
                }
            }

            return onlyperisan;
        }

        private static string FindStartTag(string[] output, int endTagCount)
        {
            int currentFindedEndTag = 0;
            for (int j =  0; j < output.Length ; j++)
            {
                if (output[j].Contains("<") && !output[j].Contains("</"))
                {
                    currentFindedEndTag++;
                    if (currentFindedEndTag == endTagCount)
                        return output[j];
                }
            }

            return "";
        }

        private static string FindEndTag(string[] output, int startTagCount)
        {
            int currentFindedEndTag = 0;
            for (int j = output.Length - 1; j >= 0; j--)
            {
                if (output[j].Contains("</"))
                {
                    currentFindedEndTag++;
                    if (currentFindedEndTag == startTagCount)
                        return output[j];
                }
            }

            return "";
        }


        /// <summary>
        /// extention for check if 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsRTL(this string text)
        {
            var isRtl = false;
            foreach (var _char in text)
            {
                if ((_char >= 1536 && _char <= 1791) || (_char >= 65136 && _char <= 65279))
                {
                    isRtl = true;
                    break;
                }
            }

            return isRtl;
        }
    }
}