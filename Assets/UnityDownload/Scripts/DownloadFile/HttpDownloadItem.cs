using System;
using System.Collections;
using System.Net;
using System.IO;
using UnityEngine;
namespace space
{
    public class HttpDownloadItem : DownloadItem
    {
        /// <summary>
        /// 临时文件后缀名
        /// </summary>
        private const string tempFileExtension=".temp";
        /// <summary>
        /// 临时文件全路径 路径+文件名+临时文件后缀名
        /// </summary>
        private string tempSaveFilePath;


        public HttpDownloadItem ( string url, string path ) : base(url, path)
        {
            tempSaveFilePath = string.Format("{0}/{1}{2}", savePath, fileName, tempFileExtension);
        }

        public override void StartDownload ( Action callBack = null )
        {
            base.StartDownload(callBack);
            DownloadHelper.Instance( ).StartCoroutine(Download(callBack));
        }

        IEnumerator Download ( Action callback=null) {
            Debug.Log( srcUrl);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( srcUrl);
            request.Method = "GET";
            FileStream fs;
            if (File.Exists(tempSaveFilePath))
            {
                //继续下载
                fs = File.OpenWrite(tempSaveFilePath);
                currentLength = fs.Length;
                fs.Seek(currentLength, SeekOrigin.Current);
                request.AddRange((int)currentLength);
            }
            else
            {
                fs = new FileStream(tempSaveFilePath, FileMode.Create, FileAccess.Write);
                currentLength = 0;
            }


            HttpWebResponse response = (HttpWebResponse)request.GetResponse( );
            Debug.Log( response);
            Stream stream = response.GetResponseStream( );
            fileLength = response.ContentLength + currentLength;
            isStartDownload = true;

            int lengthOnce;
            int bufferMaxLength = 1024 * 20;

            while (currentLength<fileLength)
            {
                byte[] buffer = new byte[bufferMaxLength];
                if (stream.CanRead)
                {
                    lengthOnce = stream.Read( buffer,0,buffer.Length);
                    currentLength += lengthOnce;
                    fs.Write( buffer,0,buffer.Length);
                }
                else
                {
                    break;
                }
                yield return null;
            }
            isStartDownload = false;
            response.Close( );
            stream.Close( );
            fs.Close( );

            File.Move( tempSaveFilePath,saveFilePath);
            if (callback!=null)
            {
                callback( );
            }
        }

        public override float GetProcess ( )
        {
            if (fileLength>0)
            {
                return currentLength / fileLength;
            }
            return 0;
        }

        public override long GetCurrentLength ( )
        {
            return currentLength;
        }

        public override long GetLength ( )
        {
            return fileLength;
        }

        public override void PauseDownload ( )
        {
            
        }
        public override void CancleDownload ( )
        {
            
        }
    }
}

