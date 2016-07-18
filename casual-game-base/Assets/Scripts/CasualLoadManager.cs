using UnityEngine;
using System.Collections;

public class CasualLoadManager : MonoBehaviour {
	private static CasualLoadManager self;
	
	/**
	 * Fancy way to call CasualSoundManager.musicPlayer
	 * If this is null, it is because it has been destroyed from a different source.
	 * */
	public static CasualLoadManager getInstance(){
		return CasualLoadManager.self;
	}
	
	/**
	 * Singleton hack for our music manager.
	 * 
	 * Yes, this sux.
	 **/
	void Awake(){
		CasualBase.CasualSocialManager mgr = CasualBase.CasualSocialManager.getInstance ();
		mgr.ShareToTwitter ("Hello World");

		GameObject currentGameObject = transform.gameObject;
		if (CasualLoadManager.self != null) {
			//Already have one? Destroy this (loaded from a different scene)
			Destroy (currentGameObject);
		} else {
			//First time here? Record it to prevent creation of more.
			CasualLoadManager.self = this;
			//With this the object is not going to be destroyed while jumping scenes.
//			DontDestroyOnLoad (currentGameObject);
		}
	}

	/**
	 * Declare your global variables here
	 * */
	private static int currentLevel = 0;
	public static int lives;

	/**
	 * Reset the status of your game.
	 * i. e. restore the max amount of lives, resets hp, repositions, set default level.
	 * */
	private void resetGame(){
		CasualLoadManager.lives = Constants.DEFAULT.LIVES;
	}
	
	/**
	 * Exposed method to be called via onClick events.
	 * */
	public void startButtonPressed(){
		//Make your on click calls here.
		resetGame ();
		loadLevel (1);
	}
	/**
	 * Exposed method to be called via onClick events.
	 * 
	 * Quit is ignored in the editor or the web player. 
	 * IMPORTANT: In most cases termination of application under iOS should be left at the user discretion. 
	 * Consult [Apple Technical Page qa1561](https://developer.apple.com/library/ios/qa/qa1561/_index.html) for further details.
	 * Reference: https://docs.unity3d.com/ScriptReference/Application.Quit.html
	 * 
	 * */
	public void exitButtonPressed(){
		//Save your stuff before leaving
		Application.Quit ();
	}

	/**
	 * Tries to load the scene by the given name
	 * 
	 * @param sceneName The name of the scene
	 * @throws Exception on Scene not found (must be added from 
	 * - File > Build Settings > Scenes in Build
	 * */
	public void loadScene(string sceneName){
		CasualLoadManager.LoadScene (sceneName);
	}
	/**
	 * Loads the scene Level_XX
	 * 
	 * @param level The XX value
	 * */
	public void loadLevel(int level){
		CasualLoadManager.LoadLevel (level);
	}

	/**
	 * Static version of this.loadScene
	 * @param sceneName The name of the scene
	 * @see loadScene
	 **/
	public static void LoadScene(string sceneName){
		Application.LoadLevel(sceneName);
	}

	private static string getLevel(int level){
		string sceneStr = (level < 10 ? "0" : "") + level;
		string sceneName = Constants.SCENES.Level + sceneStr;
		return sceneName;
	}
	/**
	 * Static version of this.loadLevel
	 * @param level The XX value
	 * @see loadLevel
	 **/
	public static void LoadLevel(int level){
		CasualLoadManager.currentLevel = level;

		string sceneName = CasualLoadManager.getLevel (level);
		CasualLoadManager.LoadScene(sceneName);
	}
	/**
	 * Increases the value of current level (static int in this file)
	 * Calls the load manager for the next level using that integer.
	 * */
	public static void nextLevel(){
		CasualLoadManager.currentLevel++;
		switch(CasualLoadManager.currentLevel){
			case 1: 
				//Make your level 1 setups here.
				CasualLoadManager.LoadLevel(1);
				break;
			// Add more levels if applicable
//			case 2: 
//				LoadManager.LoadLevel(2);
//				break;
			default:
				//Load your default Scene Here
				CasualLoadManager.LoadScene(Constants.SCENES.MAIN);
				currentLevel = 0;
				break;
		}
	}
}
