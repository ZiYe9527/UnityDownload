using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace space
{
    public class LoadImageItem : LoadItem
    {
        private string url = string.Empty;
        private string savePath = string.Empty;
        private bool isCache = false;

        public LoadImageItem ( string url) {
            this.url = url;
            isCache = false;
        }
        public LoadImageItem (string url,string savePath ) {
            this.url = url;
            this.savePath = savePath;
            isCache = true;
        }

        public void Load ( )
        {
                
        }
        

        
    }
}

