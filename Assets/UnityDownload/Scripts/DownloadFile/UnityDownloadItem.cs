using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

namespace space
{
    public class UnityDownloadItem : DownloadItem
    {
        private UnityWebRequest request;
        private int timeout=30;
        public UnityDownloadItem ( string url, string path ) : base(url, path)
        {

        }

        public override void StartDownload ( Action callBack = null )
        {
            base.StartDownload(callBack);
            DownloadHelper.Instance( ).StartCoroutine( Download(callBack));
        }

        IEnumerator Download (Action callback=null ) {

            request = UnityWebRequest.Get( srcUrl );
            isStartDownload = true;
            request.timeout = timeout;
            yield return request.SendWebRequest( );
       
            if (request.isNetworkError)
            {
                Debug.LogFormat("Download Network Error {0}",request.error );
            }
            else
            {
                byte[] bytes = request.downloadHandler.data;
                FileTools.CreateFile( saveFilePath,bytes);
            }
            isStartDownload = false;
            if (callback!=null)
            {
                callback( );
            }
        }


        public override float GetProcess ( )
        {
            if (request!=null)
            {
                return request.downloadProgress;
            }
            return 0;
        }

        public override long GetCurrentLength ( )
        {
            if (request!=null)
            {
                return (long)request.downloadedBytes;
            }
            return 0;
        }

        public override long GetLength ( )
        {
            return 0;
        }

        public override void PauseDownload ( )
        {
            
        }

        public override void CancleDownload ( )
        {
            
        }
    }
}

