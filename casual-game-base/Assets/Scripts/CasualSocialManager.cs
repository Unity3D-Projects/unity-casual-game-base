using System;
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
//			image.texture= texture ;
		}

		public void shareScreenshot(){
			TakeScreenshot ();
			string url = Constants.URL.SHARE;
		}

		private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
		private const string TWEET_LANGUAGE = "en"; 
		
		public void ShareToTwitter (string textToDisplay)
		{
			Application.OpenURL(TWITTER_ADDRESS +
			                    "?text=" + WWW.EscapeURL(textToDisplay) +
			                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
		}


		public void shareToFacebook(){
//			FB.ShareLink(
//				new Uri("https://developers.facebook.com/"),
//				//callback: ShareCallback
//			);

//		https://developers.facebook.com/docs/unity/reference/current/FB.ShareLink
//			public static void ShareLink(
//				Uri contentURL = null,
//				string contentTitle = "",
//				string contentDescription = "",
//				Uri photoURL = null,
//				FacebookDelegate<IShareResult> callback = null
//			)
		}
	}
}
