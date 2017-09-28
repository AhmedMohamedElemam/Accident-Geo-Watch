using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aciident_Geo_Watch
{
    class Stemmer
    {
        string[] p3 = new string[5] { "ولل", "وال", "كال", "بال", "فال" };
        string[] p2 = new string[2] { "ال", "لل" };
        string[] p1 = new string[9] { "ل", "ب", "ف", "س", "و", "ي", "ت", "ن", "ا" };

        string[] s3 = new string[5] { "تمل", "همل", "تان", "تين", "كمل" };

        string[] s2 = new string[16] 
        { "ون", "ات", "ان", "ين",
          "تن", "كم", "هن", "نا",
          "يا", "ها", "تم", "كن",
          "ني", "وا", "ما","هم" };

        string[] s1 = new string[7] { "ة", "ه", "ي", "ك", "ت", "ا", "ن" };

        string[] pr4 = new string[6] { "-ا--",
            "--و-", "---ة", "--ا-", "--ي-", "م---" };

        string[] pr53 = new string[26] {
        "ت-ا--","ا-ت--","ا--ا-","ا-ا--","--ا-ة","---ان","--و-ة","ت---ة",
        "ت--ي-","م---ة","م--و-","-ا-و-","-وا--","م--ا-","م--ي-","ا---ة",
        "--اا-","من---","م-ت--","-ا--ة","م-ا--","-ملا-","ي-ت--","ت-ت--",
        "--ا-ي","ان---"};

        string[] pr54 = new string[6] { "ت----", "ا----", "م----", "----ة", "--ا--", "---ا-" };

        string[] pr63 = new string[5] { "است---", "م--ا-ة",
            "ا-ت-ا-","ا--وع-","مست---" };

        string[] pr64 = new string[3] { "ا-ن--", "ا---ا-", "مت----" };

        bool prefix_removed;
        public string st1, st2, st3, st4, st5, st6, st7;

        public string Stem(string word)
        {
            st1 = st2 = st3 = st4 = st5 = st6 = st7 = "";
            char[] all_chars = new char[word.Length];
            all_chars = word.ToCharArray();

            for (int i = 0; i < all_chars.Length; i++)
            {
                //should be in range [1569-1594] & [1601-1610]
                if (Convert.ToInt32(all_chars[i]) < 1569 ||
                    (Convert.ToInt32(all_chars[i]) > 1594 &&
                    Convert.ToInt32(all_chars[i]) < 1601) ||
                    Convert.ToInt32(all_chars[i]) > 1610)
                {
                    all_chars[i] = 'x';
                }
                //remove hamza
                else if (Convert.ToInt32(all_chars[i]) >= 1569 &&
                    Convert.ToInt32(all_chars[i]) <= 1574)
                {
                    all_chars[i] = 'ا';
                }
            }
            word = m_chars_ToString(all_chars);
            word = word.Replace("x", "");
            st1 = word;
            //Remove length three and length two sufixes
            prefix_removed = m_remove_sufix(ref word, s3);
            if (!prefix_removed)
            {
                m_remove_sufix(ref word, s2);
            }
            //Remove length three and length two prefxes 
            prefix_removed = m_remove_prefix(ref word, p3);
            if (!prefix_removed)
            {
                m_remove_prefix(ref word, p2);
            }
            st2 = word;
            if (word.Length <= 3)
                return word;
            else if (word.Length == 4)
            {
                return m_length_4(word);
            }
            else if (word.Length == 5)
            {
                return m_length_5(word);
            }
            else if (word.Length == 6)
            {
                return m_length_6(word);

            }
            else if (word.Length == 7)
            {
                return m_length_7(word);
            }
            return word;
        }

        private string m_chars_ToString(char[] chars)
        {
            string word = "";
            for (int i = 0; i < chars.Length; i++)
            {
                word += chars[i];
            }
            return word;
        }

        private string m_length_4(string word)
        {
            string temp_word = m_matches_patterns(word, pr4);
            if (temp_word == word)
            {
                prefix_removed = m_remove_sufix(ref word, s1);
                if (!prefix_removed)
                {
                    m_remove_prefix(ref word, p1);
                }
                st4 = word;
                return word;
            }
            else
            {
                st3 = temp_word;
                return temp_word;
            }
        }

        private string m_length_5(string word)
        {
            string temp_word = m_matches_patterns(word, pr53);
            if (temp_word == word)
            {
                prefix_removed = m_remove_sufix(ref word, s2);
                if (!prefix_removed)
                {
                    prefix_removed = m_remove_prefix(ref word, p2);
                }

                if (word.Length == 5)
                {
                    return m_matches_patterns(word, pr54);
                }
                st5 = word;
                return word;
            }
            else
            {
                st5 = temp_word;
                return temp_word;
            }
        }

        private string m_length_6(string word)
        {
            string temp_word = m_matches_patterns(word, pr63);
            if (temp_word == word)
            {
                prefix_removed = m_remove_sufix(ref word, s1);
                if (prefix_removed)
                {
                    st6 = m_length_5(word); ;
                    return st6;
                }
                prefix_removed = m_remove_prefix(ref word, p1);
                if (prefix_removed)
                {
                    st6 = m_length_5(word); ;
                    return st6;
                }
                st6 = word;
                return word;
            }
            else
            {
                st6 = temp_word;
                return temp_word;
            }
        }

        private string m_length_7(string word)
        {
            prefix_removed = m_remove_sufix(ref word, s1);
            if (prefix_removed)
            {
                st7 = m_length_6(word);
                return st7;
            }
            prefix_removed = m_remove_prefix(ref word, p1);
            if (prefix_removed)
            {
                st7 = m_length_6(word);
                return st7;
            }
            st7 = word;
            return word;
        }

        private bool m_remove_prefix(ref string word, string[] p_group)
        {
            foreach (string item in p_group)
            {
                if (word.Substring(0, item.Length) == item)
                {
                    word = word.Remove(0, item.Length);
                    return true;
                }
            }
            return false;
        }

        private bool m_remove_sufix(ref string word, string[] p_group)
        {

            foreach (string item in p_group)
            {
                if (word.Substring(word.Length - item.Length) == item)
                {
                    word = word.Remove(word.Length - item.Length);
                    return true;
                }
            }
            return false;
        }

        private string m_matches_patterns(string word, string[] p_group)
        {
            bool item_match = true;
            List<char> fe3el = new List<char>();
            foreach (string item in p_group)
            {
                item_match = true;
                if (item.Length == word.Length)
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (item[i] != '-')
                        {
                            if (item[i] != word[i])
                            {
                                item_match = false;
                                fe3el.Clear();
                                break;
                            }
                        }
                        else
                        {
                            fe3el.Add(word[i]);
                        }
                    }
                    if (item_match)
                    {
                        return m_chars_ToString(fe3el.ToArray());
                    }
                }
            }
            return word;
        }
    }
}
