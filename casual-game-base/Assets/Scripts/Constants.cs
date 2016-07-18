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
	public static class URL {
		public static string SHARE = "https://play.google.com/store/apps/details?id=com.fifino.flappydroid";
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

