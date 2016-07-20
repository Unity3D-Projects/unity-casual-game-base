using UnityEngine;
using CasualBase;

public class CasualLoadController : MonoBehaviour {
    CasualLoadManager manager;
    void Start(){
        manager = CasualLoadManager.getInstance();
    }
    /**
     * Exposed method to be called via onClick events.
     * */
    public void startButtonPressed(){
        //Make your on click calls here.
        manager.resetGame ();
        manager.loadLevel (1);
    }
    /**
     * Exposed method to be called via onClick events.
     * */
    public void backButtonPressed(){
        //Make your on click calls here.
        manager.loadScene (Constants.SCENES.MAIN);
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
}
