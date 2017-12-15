using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace Common
{
    public static class EncryptHelper 
    {

        #region ========DES加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string sInputString)
        {
            return DESEncryptString(sInputString, "MATICSOFT");
        }


        #endregion

        #region ========DES解密========


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string sInputString)
        {
            return DESDecryptString(sInputString, "MATICSOFT");
        }
      

        #endregion


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5DecryptString(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5Source = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Out = md5.ComputeHash(md5Source);
            return Convert.ToBase64String(md5Out);
            
        }

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="sInputString">输入字符</param>
        /// <param name="sKey">Key</param>
        /// <returns>加密结果</returns>
        public static string DESEncryptString(string sInputString, string sKey)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(sInputString);
                byte[] result;
                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey); //密钥
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey); //初始化向量
                ICryptoTransform desencrypt = DES.CreateEncryptor(); //加密器对象
                result = desencrypt.TransformFinalBlock(data, 0, data.Length); //转换指定字节数组的指定区域
                return BitConverter.ToString(result);
            }
            catch (Exception ex)
            {
                //ex.Message = "DES加密异常";
                throw ex;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="sInputString">输入字符</param>
        /// <param name="sKey">Key</param>
        /// <returns>解密结果</returns>
        public static string DESDecryptString(string sInputString, string sKey)
        {
            try
            {
                //将字符串转换为字节数组
                string[] sInput = sInputString.Split("-".ToCharArray());
                byte[] data = new byte[sInput.Length];
                byte[] result;
                for (int i = 0; i < sInput.Length; i++)
                {
                    data[i] = byte.Parse(sInput[i], System.Globalization.NumberStyles.HexNumber);
                }

                DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
                DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = DES.CreateDecryptor();
                result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return Encoding.Default.GetString(result);
            }
            catch (Exception ex)
            {
                //ex.Message = "DES解密异常";
                throw ex;
            }
        } 


    }
}
