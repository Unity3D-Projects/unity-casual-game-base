using UnityEngine;

namespace CasualBase
{
    /**
     * Manager class for social sharing basics.
     * */
    public class CasualSocialManager  {
        private static CasualSocialManager self = null;
        private CasualSocialManager(){ }
        
        public static CasualSocialManager getInstance(){
            if (CasualSocialManager.self == null) {
                CasualSocialManager.self = new CasualSocialManager();
            }
            return CasualSocialManager.self;
        }
        
        public void ShareToTwitter(float score){
            this.ShareToTwitter(getScoreText(score));
        }
        public void ShareToTwitter (string textToDisplay)
        {
			string url = Constants.SOCIAL.TWITTER.URL +
			             Constants.SOCIAL.TWITTER.Q_TEXT + WWW.EscapeURL (textToDisplay) +
			             Constants.SOCIAL.TWITTER.Q_LANG + WWW.EscapeURL (Constants.SOCIAL.TWITTER.LANG);
			Application.OpenURL(url);
        }
        
        public void ShareToFacebook(float score){
            this.ShareToFacebook(getScoreText(score));
        }
        private string getScoreText(float score){
            return "Got a " + score + "points on " + Constants.NAME;
        }
        
        /**
         * Opens the URL in browser with facebook share dialog
         * */
        public void ShareToFacebook(string description){
            this.ShareToFacebook(Constants.SOCIAL.FACEBOOK.CAPTION, Constants.SOCIAL.FACEBOOK.NAME, description, Constants.SOCIAL.FACEBOOK.PICTURE);
        }
        /**
         * Opens the URL in browser with twitter share dialog
         * */
		public void ShareToFacebook(string caption, string name, string description, string picture){
			string url = Constants.SOCIAL.FACEBOOK.URL + Constants.SOCIAL.FACEBOOK.Q_APP_ID +
				Constants.SOCIAL.FACEBOOK.APP_ID +
				Constants.SOCIAL.FACEBOOK.Q_LINK + WWW.EscapeURL(Constants.SOCIAL.SHARE) +
				Constants.SOCIAL.FACEBOOK.DISPLAY +
				Constants.SOCIAL.FACEBOOK.Q_CAPTION + WWW.EscapeURL(caption) +
				Constants.SOCIAL.FACEBOOK.Q_NAME + WWW.EscapeURL(name) + 
				Constants.SOCIAL.FACEBOOK.Q_DESCRIPCION + WWW.EscapeURL(description);
			if(picture != null){
				url+=  Constants.SOCIAL.FACEBOOK.Q_PICTURE + WWW.EscapeURL(picture);
			}
			Application.OpenURL(url);
        }
        
        
        //        public void TakeScreenshot(){
        //            Application.CaptureScreenshot(Constants.FILES.SCREENSHOT);
        //        }
        //        public void GetPhoto()
        //        {
        //            RawImage image;
        //            string url = Application.persistentDataPath + "/" + Constants.FILES.SCREENSHOT;
        //            byte[] bytes = File.ReadAllBytes( url );
        //            Texture2D texture = new Texture2D( 73, 73 ); // TODO: 73 ?
        //            texture.LoadImage( bytes );
        //            //                        image.texture= texture ;
        //        }
        //        
        //        public void shareScreenshot(){
        //            TakeScreenshot ();
        //        }
        
    }
}
