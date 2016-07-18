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
}

