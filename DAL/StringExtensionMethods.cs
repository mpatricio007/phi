﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Medusa.DAL
{
    public static class StringExtensionMethods
    {
        private static byte[] chave = { };
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };
        public static string Criptografar(this string valor)
        {
            string rt = valor;
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; 
            byte[] input;
            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = Encoding.UTF8.GetBytes(valor); 
                chave = Encoding.UTF8.GetBytes(LIB.Constantes.CHAVE_CRIPTOGRAFICA);
                cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception)
            {
                return rt;
            } 
        }

        public static string DesCriptografar(this string valor)
        {
            string rt = valor;
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; 
            byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();
                input = new byte[valor.Length];
                input = Convert.FromBase64String(valor.Replace(" ", "+"));
                chave = Encoding.UTF8.GetBytes(LIB.Constantes.CHAVE_CRIPTOGRAFICA);
                cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return rt;
            }
        }
    }
}