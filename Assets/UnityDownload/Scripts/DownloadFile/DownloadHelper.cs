using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace space
{
	public class DownloadHelper : MonoBehaviour 
	{
        private static DownloadHelper instance;
        public static DownloadHelper Instance ( ) {
            if (instance==null)
            {
                instance = new GameObject("DownloadHelper").AddComponent<DownloadHelper>();
            }
            return instance;
        }
    }
}

