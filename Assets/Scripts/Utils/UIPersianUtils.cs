using System;
using System.Collections;
using System.Collections.Generic;
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
            text = ArabicSupport.ArabicFixer.Fix(text,true,false);
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
            for (int i = 0; i < output.Length; i++)
            {
                textWithMeta += output[i].Contains("<") ? output[i] : output[i].ToPersian();
            }
            return textWithMeta;
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

