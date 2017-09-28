using System;
using System.Collections.Generic;
using System.Text;

namespace Aciident_Geo_Watch
{
    class StopWords
    {
        static Dictionary<string, bool> stop_words = new Dictionary<string, bool>
    {
        { "عن", true },
        { "عند", true },
        { "عندما", true },
        { "على", true },
        { "عليه", true },
        { "عليها", true },
        { "تم", true },
        { "ضد", true },
        { "بعد", true },
        { "بعض", true },
        { "حتى", true },
        { "إذا", true },
        { "أحد", true },
        { "بان", true },
        { "أجل", true },
        { "غير", true },
        { "به", true },
        { "ثم", true },
        { "إن", true },
        { "أو", true },
        { "أي", true },
        { "بها", true },
        { "حيث", true },
        { "إلا", true },
        { "أما", true },
        { "التي", true },
        { "أكثر", true },
        { "أيضا", true },
        { "الذى", true },
        { "الأن", true },
        { "الذين", true },
        { "ذلك", true },
        { "دون", true },
        { "حول", true },
        { "حين", true },
        { "إلى", true },
        { "أنه", true },
        { "أول", true },
        { "أنها", true },
        { "و", true },
        { "قد", true },
        { "لا", true },
        { "ما", true },
        { "مع", true },
        { "هذا", true },
        { "وأضاف", true },
        { "وأضافت", true },
        { "قبل", true },
        { "قال", true },
        { "كان", true },
        { "لدى", true },
        { "نحو", true },
        { "هذه", true },
        { "وأن", true },
        { "أن", true },
        { "أكد", true },
        { "وأكد", true },
        { "كانت", true },
        { "وأوضح", true },
        { "فى", true },
        { "في", true },
        { "كل", true },
        { "لم", true },
        { "لن", true },
        { "له", true },
        { "من", true },
        { "هو", true },
        { "هي", true },
        { "كما", true },
        { "لها", true },
        { "منذ", true },
        { "وقد", true },
        { "ولا", true },
        { "لقاء", true },

        { "مقابل", true },
        { "هناك", true },
        { "وقال", true },
        { "وكان", true },
        { "وقالت", true },
        { "وكانت", true },

        { "فيه", true },
        { "لكن", true },
        { "وفي", true },
        { "ولم", true },
        { "ومن", true },
        { "وهو", true },
        { "وهي", true },
        { "يوم", true },
        { "فيها", true },
        { "منها", true },
        { "يكون", true },
        
        { "يمكن", true },
        { "بدون", true },
        { "آخر", true }, 
        { "وآخر", true },
        { "بما", true },
        { "وتولت", true },
        { "تولت", true },
        { "وتحرر", true },
        { "جاء", true },
        { "الأول", true },
        { "العام", true },
        { "سبق", true },
        { "أمرت", true },

           { "خارج", true },
           { "داخل", true },
           { "بقصد", true },
           { "اللازم", true },
           { "لو", true },
           { "تلك", true },
           { "سنة", true },
           { "اللى", true },
           { "إيه", true },
           { "يتم", true },
           { "إغلاق", true },
           { "منع", true },
           { "كافة", true },
           { "بينها", true },
           { "وقرر", true },
           { "قرر", true },
           { "وأثناء", true },
           { "أثناء", true },
           { "وجاءت", true },
           { "جاءت", true },
           { "اليوم", true },
           { "الأربعاء", true },
           { "السبت", true },
           { "الأحد", true },
           { "الأثنين", true },
             { "الثلاثاء", true },

              { "وعندما", true },
               { "إنها", true },
              { "انها", true },
              { "ا", true },
              { "أ", true },
              
              { "ب", true },
              { "ت", true },
              { "ث", true },
              { "ج", true },
              { "ح", true },
              { "خ", true },
              { "د", true },
              { "ذ", true },
              { "ر", true },
              { "ز", true },
              { "س", true },
              { "ش", true },
              { "ص", true },
              { "ض", true },
              { "ط", true },
              { "ظ", true },
              { "ع", true },
              { "غ", true },
              { "ف", true },
              { "ق", true },
              { "ك", true },
              { "ل", true },
              { "م", true },
              { "ن", true },
              { "ه", true },
              { "ى", true },


            { "أى", true },
            { "إنه", true },
            { "بسبب", true },
            { "أخرى", true },
            { "وتم", true },
                  
                    { "اخرى", true },

               { "الخميس", true },
               { "الجمعة", true },
               { "فقط", true },
               { "أولى", true },
               { "بأنه", true },
               { "والذى", true },
        { "بالفيديو", true },
        { "بالصور", true }
    };


        static char[] delimiters = new char[]
    {
        ' ',
        ',',
        ';',
        '؟',
        '-',
        '!',
        ')',
        '،',
        '(',
        '.'
    };


        public static string remove_stop_words(string input)
        {
            // 1
            // Split parameter into words
            var words = input.Split(delimiters,
                StringSplitOptions.RemoveEmptyEntries);

            // 3
            // Store results in this StringBuilder
            StringBuilder builder = new StringBuilder();
            // 4
            // Loop through all words
            foreach (string currentWord in words)
            {

                // 5
                // If this is a usable word, add it
                if (!stop_words.ContainsKey(currentWord))
                {
                    builder.Append(currentWord).Append(' ');
                }
            }
            // 6
            // Return string with words removed
            return builder.ToString().Trim();
        }
    }
}
