using UnityEngine;

public class BorderController : MonoBehaviour {
    CasualPingPong pingPongController;
    
    void Start(){
        GameObject pingPong = GameObject.Find("PingPong");
        pingPongController = pingPong.GetComponent<CasualPingPong>();
    }
    
    void OnCollisionEnter2D(Collision2D collider){
        pingPongController.reset();
    }
}
