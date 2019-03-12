using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
namespace space
{
    public class WWWDownloadItem : DownloadItem
    {
        WWW www;
        public WWWDownloadItem ( string url, string path ) : base(url, path)
        {

        }

        public override void StartDownload ( Action callBack = null )
        {
            base.StartDownload( );
            DownloadHelper.Instance().StartCoroutine(Download( callBack ));
        }

        IEnumerator Download (Action callBack=null ) {
            www = new WWW( srcUrl);
            isStartDownload = true;
            Debug.Log(www.progress);
            yield return www;
            isStartDownload = false;
            Debug.Log(www.progress);
            if (www.isDone)
            {
                byte[] bytes = www.bytes;
                FileTools.CreateFile( saveFilePath,bytes);
            }
            else
            {
                Debug.LogFormat( "Download Error:{0}",www.error);
            }
            if (callBack!=null)
            {
                callBack( );
            }
        }

        public override float GetProcess ( )
        {
            if (www != null)
                return www.progress;
            return 0;
        }

        public override long GetCurrentLength ( )
        {
            if (www != null)
            {
                return www.bytesDownloaded;
            }
            return 0;
        }

        public override long GetLength ( )
        {
            if (www != null)
            {
                return 0;
            }
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

