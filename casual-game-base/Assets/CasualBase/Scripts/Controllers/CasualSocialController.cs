using UnityEngine;
using CasualBase;

/**
 * Social Sharing controller, exposes the social network click events so they can be attached to the UI
 * */
public class CasualSocialController : MonoBehaviour {
    private CasualSocialManager manager;
    // Use this for initialization
    void Start () {
        manager = CasualSocialManager.getInstance();
    }
    
    public void FacebookClicked(){
        manager.ShareToFacebook("Playing " + Constants.NAME);
    }
    public void TwitterClicked(){
        manager.ShareToTwitter ("Playing " + Constants.NAME);
    }
    private float getScore(){
        return 0; //Return your score
    }
    
    public void FacebookScoreClicked(){
        manager.ShareToFacebook(getScore());
    }
    
    public void TwitterScoreClicked(){
        manager.ShareToTwitter (getScore());
    }
}
