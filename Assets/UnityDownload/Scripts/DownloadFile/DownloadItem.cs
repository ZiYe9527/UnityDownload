using System.IO;
using System;
namespace space
{
    /// <summary>
    /// 
    /// </summary>
	public abstract class DownloadItem 
	{
        /// <summary>
        /// 网络资源路径
        /// </summary>
        protected string srcUrl;
        /// <summary>
        /// 文件保存路径，不包含文件名
        /// </summary>
        protected string savePath;
        /// <summary>
        /// 文件名，不包含文件后缀名
        /// </summary>
        protected string fileName;
        /// <summary>
        /// 文件后缀名
        /// </summary>
        protected string fileExtension;
        /// <summary>
        /// 下载文件全路径，路径+文件名+后缀名
        /// </summary>
        protected string saveFilePath;
        /// <summary>
        /// 文件大小
        /// </summary>
        protected long fileLength;
        /// <summary>
        /// 当前下载好的大小
        /// </summary>
        protected long currentLength;

        /// <summary>
        /// 是否开始下载
        /// </summary>
        protected bool isStartDownload;
        public bool IsStartDownload {
            get {
                return isStartDownload;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        public DownloadItem (string url,string path) {
            srcUrl = url;
            savePath = path;
            isStartDownload = false;
            fileName = FileTools.MD5Encript(url, path);
            fileExtension = Path.GetExtension( srcUrl );
            saveFilePath = string.Format( "{0}/{1}",savePath,fileName);
        }

        /// <summary>
        /// 开始下载
        /// </summary>
        /// <param name="callBack"></param>
        public virtual void StartDownload (Action callBack = null ) {
            if (string.IsNullOrEmpty(srcUrl))
                return;
            if (string.IsNullOrEmpty(savePath))
                return;
            FileTools.CreateDirectory( savePath );
        }

        /// <summary>
        /// 获取下载进度
        /// </summary>
        /// <returns></returns>
        public abstract float GetProcess ( );
        /// <summary>
        /// 获取当前下载好的文件大小
        /// </summary>
        /// <returns></returns>
        public abstract long GetCurrentLength ( );
        /// <summary>
        /// 获取要下载文件的大小
        /// </summary>
        /// <returns></returns>
        public abstract long GetLength ( );
        /// <summary>
        /// 暂停下载
        /// </summary>
        public abstract void PauseDownload ( );
        /// <summary>
        /// 取消下载
        /// </summary>
        public abstract void CancleDownload ( );
	}
}

