﻿using UnityEngine;
using System.Collections;
using CasualBase;

public class SocialController : MonoBehaviour {
    CasualSocialManager manager;
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
