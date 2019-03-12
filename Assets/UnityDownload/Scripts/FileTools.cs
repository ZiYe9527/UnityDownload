using System.IO;
using System.Security.Cryptography;
using UnityEngine;
using System.Text;
namespace space
{
	public static class FileTools
	{

        public static void CreateDirectory (string path ) {
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogFormat( "{0} can not be Null Or Empty!!",path);
                return;
            }
            if (Directory.Exists(path))
                return;
            Directory.CreateDirectory( path );
        }

        public static void CreateFile (string filePath, byte[] bytes ) {
            
            FileInfo file = new FileInfo(filePath);
            using (Stream stream = file.Create( ))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close( );
                stream.Dispose( );
            }  
        }
        /// <summary>
        /// 使用MD5加密链接,并隐藏文件名字
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string MD5Encript ( string url ,string savePath )
        {
            string key = string.Empty;
            byte[] data = Encoding.UTF8.GetBytes(url + savePath);
            MD5 md5 = new MD5CryptoServiceProvider( );
            byte[] encryptdata = md5.ComputeHash(data);
            for (int i = 0; i < encryptdata.Length; i++)
            {
                key = key + encryptdata[i].ToString("x");

            }
            return key;
        }
    }
}

