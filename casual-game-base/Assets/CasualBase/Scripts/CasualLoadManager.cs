using UnityEngine;
using UnityEngine.SceneManagement;

namespace CasualBase {
    /**
     * Our custom SceneManager with some exposed methods for the UI
     * */
    
    public class CasualLoadManager  {
        private static CasualLoadManager self = null;
        private CasualLoadManager(){ }
        
        public static CasualLoadManager getInstance(){
            if (CasualLoadManager.self == null) {
                CasualLoadManager.self = new CasualLoadManager();
            }
            return CasualLoadManager.self;
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
        public void resetGame(){
            CasualLoadManager.lives = Constants.DEFAULT.LIVES;
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
            SceneManager.LoadScene(sceneName);
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
                //          case 2: 
                //              LoadManager.LoadLevel(2);
                //              break;
            default:
                //Load your default Scene Here
                CasualLoadManager.LoadScene(Constants.SCENES.MAIN);
                currentLevel = 0;
                break;
            }
        }
    }
}
