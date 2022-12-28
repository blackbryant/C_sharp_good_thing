class CodeUtility
    {
        /// <summary>
        /// XML特殊字元轉成全形
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string XmlSpecCharToSBC(string s) 
        {
            string result=s;
            if (result.Contains("<"))
            {
                result = result.Replace("<",ToSBC("<"));
            }
          
            if (s.Contains(">"))
            {
                result = result.Replace(">", ToSBC(">"));

            }
           
            if (s.Contains("&"))
            {
                result = result.Replace("&", ToSBC("&"));
            }
           
            if (s.Contains("'"))
            {
               
                result = result.Replace("'", ToSBC("'"));
            }
            
            if (s.Contains("\""))
            {
                result = result.Replace("\"", ToSBC("\""));
            }
           

            return result; 
        }

        /// <summary>
        /// 特殊字元
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsXmlSpecialChar(string s) 
        {
            bool isSChat = false;
            if (s.Contains("<"))
            {
                isSChat = true; 
            } else if (s.Contains(">")) 
            {
                isSChat = true;
            } else if (s.Contains("&"))
            {
                isSChat = true;
            }
            else if (s.Contains("'"))
            {
                isSChat = true;
            }
            else if (s.Contains("\""))
            {
                isSChat = true;
            }

            return isSChat; 
        }

        /// <summary>
        /// 轉全形的函數(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String ToSBC(String input)
        {
           
            // 半形轉全形：
            char[] c = input.ToCharArray();
            
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32) //半形空格為32
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
           
            return new String(c);
        }

        /// <summary>
        /// 轉半形的函數(DBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }
