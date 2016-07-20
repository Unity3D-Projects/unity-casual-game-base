﻿using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace CasualBase
{
    public class CasualSocialManager  {
        private static CasualSocialManager self = null;
        private CasualSocialManager(){ }
        
        public static CasualSocialManager getInstance(){
            if (CasualSocialManager.self == null) {
                CasualSocialManager.self = new CasualSocialManager();
            }
            return CasualSocialManager.self;
        }
        
        public void TakeScreenshot(){
            Application.CaptureScreenshot(Constants.FILES.SCREENSHOT);
        }
        public void GetPhoto()
        {
            RawImage image;
            string url = Application.persistentDataPath + "/" + Constants.FILES.SCREENSHOT;
            byte[] bytes = File.ReadAllBytes( url );
            Texture2D texture = new Texture2D( 73, 73 ); // TODO: 73 ?
            texture.LoadImage( bytes );
            //                        image.texture= texture ;
        }
        
        public void shareScreenshot(){
            TakeScreenshot ();
        }
        
        public void ShareToTwitter (string textToDisplay)
        {
			Application.OpenURL(Constants.SOCIAL.TWITTER.URL +
								Constants.SOCIAL.TWITTER.Q_TEXT + WWW.EscapeURL(textToDisplay) +
								Constants.SOCIAL.TWITTER.Q_LANG + WWW.EscapeURL(Constants.SOCIAL.TWITTER.LANG));
        }
		public void ShareToFacebook(){
			Application.OpenURL(
				Constants.SOCIAL.FACEBOOK.URL + Constants.SOCIAL.FACEBOOK.APP_ID +
				Constants.SOCIAL.FACEBOOK.Q_APP_ID +
				Constants.SOCIAL.FACEBOOK.Q_LINK + Constants.SOCIAL.SHARE +
				Constants.SOCIAL.FACEBOOK.DISPLAY +
				Constants.SOCIAL.FACEBOOK.Q_CAPTION + Constants.SOCIAL.FACEBOOK.CAPTION +
				Constants.SOCIAL.FACEBOOK.Q_NAME + name + 
				Constants.SOCIAL.FACEBOOK.Q_DESCRIPCION + description

			);
            //https://www.facebook.com/dialog/feed?%20app_id=231019603765682&%20link=http://google.com
        }
        
    }
}
