/**
 * Scene, tags, input names, scene objects and default values are some of the constants we may be preserve in one place.
 * */
public class Constants
{
	//List of Scenes, Prefix, Sufix values.
	public static class SCENES {
		public static string MAIN = "CasualMain";
		public static string Level = "CasualLevel_";
	}

	//List of Tags
	public static class TAG {
		public static string PLAYER = "Player";
		public static string BRICKS = "BRICKS";
	}

	//List of Inputs
	public static class INPUT {
		public static string HORIZONTAL = "Horizontal";
		public static string FIRE = "Fire1";
	}

	//List of Some in game default values
	public static class DEFAULT {
		public static int LIVES = 3;
	}
	
	//List of Some common objects in the scene
	public static class SCENE_OBJECTS {
		public static string CAMERA = "Main Camera";
		public static string MENU = "_CasualMenu";

		public static class CASUAL {
			public static string BASE = "_CasualBase";
			public static string LOAD_MANAGER = "CasualLoadManager";
			public static string SOUND_MANAGER = "_CasualSoundManager";

			public static string BALL = "ball";
		}
	}

	public static class FILES {
		public static string SUFFIX = ".casual";
		public static string PREFIX = "_";

		public static string SCREENSHOT = "__screenshot__.png";
		public static string RECORDS = Constants.FILES.PREFIX + "records" + Constants.FILES.SUFFIX;
	}
	public static class SOCIAL {
//		public static string SHARE = "https://play.google.com/store/apps/details?id=com.fifino.flappydroid";
		public static string SHARE = "https://play.google.com/store/apps/developer?id=porfiriopartida";
		public static class TWITTER {
			public static string URL = "http://twitter.com/intent/tweet?";
			public static string LANG = "en";
			public static string Q_TEXT = "text=";
			public static string Q_LANG = "&amp;lang=";
		}

		public static class FACEBOOK {
			public static string URL = "https://www.facebook.com/dialog/feed?";
			public static string Q_APP_ID = "app_id=";
			public static string APP_ID = "231019603765682";

			public static string Q_LINK = "&link=";
			public static string DISPLAY = "&display=page";
			public static string Q_CAPTION = "&caption=Gotta%20Catch%20Em%20All";
			public static string Q_NAME = "&name=pokego";
			public static string Q_DESCRIPCION = "&description=ezpz";
		}
	}
	public enum Environment { WINDOWS, WEB, IOS, ANDROID, OTHER };

#if UNITY_IOS
	public static Environment CURRENT_ENVIRONMENT = Environment.IOS;
#elif UNITY_ANDROID
	public static Environment CURRENT_ENVIRONMENT = Environment.ANDROID;
#elif UNITY_WINDOWS
	public static Environment CURRENT_ENVIRONMENT = Environment.WINDOWS;
#elif UNITY_WEBGL
	public static Environment CURRENT_ENVIRONMENT = Environment.WEB;
#else
	public static Environment CURRENT_ENVIRONMENT = Environment.OTHER;
#endif
}

