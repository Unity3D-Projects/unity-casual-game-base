using UnityEngine;

public class BorderController : MonoBehaviour {
    private CasualSoundManager soundManager;
    CasualPingPong pingPongController;
    
    void Start(){
        GameObject pingPong = GameObject.Find("PingPong");
        soundManager = CasualSoundManager.getInstance();
        pingPongController = pingPong.GetComponent<CasualPingPong>();
    }
    
    void OnCollisionEnter2D(Collision2D collider){
        pingPongController.reset();
        soundManager.playSound(CasualSoundManager.SFX.SUCCESS);
    }
}
