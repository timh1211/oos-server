﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace OOS.Utilities
{
    public class Utility
    {
        private static readonly byte[] bytes = Encoding.ASCII.GetBytes("LeVanHau");
        public static void CloneObject(object des, object src)
        {
            foreach (PropertyInfo propertyInfo in des.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (src.GetType().GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance) != null)
                {
                    var value = src.GetType().GetProperty(propertyInfo.Name).GetValue(src, null);
                    propertyInfo.SetValue(des, value, null);
                }
            }
        }

        public static string HashMD5(string text)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var encoder = new UTF8Encoding();
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(text));
            return hashedBytes.Aggregate(string.Empty, (current, next) => current + next.ToString("x2"));
        }

        public static string Encrypt(string originalString)
        {
            if (string.IsNullOrWhiteSpace(originalString))
            {
                return string.Empty;
            }

            var cryptoProvider = new DESCryptoServiceProvider();
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            var writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string Decrypt(string cryptedString)
        {
            if (string.IsNullOrWhiteSpace(cryptedString))
            {
                return string.Empty;
            }

            var cryptoProvider = new DESCryptoServiceProvider();
            var memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            var cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            var reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        public static Guid? CurrentUserId
        {
            get
            {
                try
                {
                    var token = HttpContext.Current.Request.Headers.Get("token").ToString();
                    var userId = Decrypt(token);
                    var result = Guid.Empty;
                    if (Guid.TryParse(userId, out result)) return result;
                    else return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static string SaveImage(dynamic file)
        {
            if (file.size > 0)
            {
                string imgPath = Path.GetFileName(file.name);
                string url = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Image/"), imgPath);
                file.SaveAs(url);
                return "~/Image/" + imgPath;
            }
            return "~/Image/img_unload.png";
        }
    }
}
