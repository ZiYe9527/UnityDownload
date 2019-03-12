using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace space
{
	public class LoadImageTest : MonoBehaviour 
	{
        private void Start ( )
        {
            Image image = GetComponent<Image>( );
            
            LoadImageItem item = new LoadImageItem( "https://jkjyvideo.oss-cn-shenzhen.aliyuncs.com/JKJY/Img/10012.png",Application.persistentDataPath+"/Image");
        }

    }
}

