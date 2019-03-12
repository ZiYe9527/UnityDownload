using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace space
{
	public class DownloadTest : MonoBehaviour 
	{
        public Image img;
        string testScrUrl = @"https://jkjyvideo.oss-cn-shenzhen.aliyuncs.com/JKJY/Img/10012.png";
        DownloadItem item;
        private void Start ( )
        {
            item = new WWWDownloadItem(testScrUrl,Application.streamingAssetsPath);
            //item = new UnityDownloadItem(testScrUrl, Application.streamingAssetsPath);
            item.StartDownload( delegate () {
                Debug.Log( "下载完成");
            });
        }

        private void Update ( )
        {
            if (item!=null  && item.IsStartDownload)
            {
                Debug.LogFormat("下载进度-----{0}---,已下载大小{1}---,文件总大小{2}",item.GetProcess( ),item.GetCurrentLength(),item.GetLength());
            }
           
        }

    }
}

