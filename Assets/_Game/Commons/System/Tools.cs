using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Game
{
    public class Tools
    {
        public static string GetMd5Hash(string pInput)
        {
            MD5 md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pInput));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string StrToBase64(string pVal)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(pVal);
//转成 Base64 形式的 System.String  
            var result = Convert.ToBase64String(b);
            return result;
        }

        public static string Base64ToStr(string pVal)
        {
            byte[] c = Convert.FromBase64String(pVal);  
            var result = System.Text.Encoding.Default.GetString(c);  
            return result;
        }
    }


    public static class UITools
    {
        public static void SetSize(this RectTransform trans, Vector2 newSize)
        {
            Vector2 oldSize = trans.rect.size;
            Vector2 deltaSize = newSize - oldSize;
            trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
            trans.offsetMax = trans.offsetMax +
                              new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
        }

        public static void SetWidth(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(newSize, trans.rect.size.y));
        }

        public static void SetHeight(this RectTransform trans, float newSize)
        {
            SetSize(trans, new Vector2(trans.rect.size.x, newSize));
        }
    }
}