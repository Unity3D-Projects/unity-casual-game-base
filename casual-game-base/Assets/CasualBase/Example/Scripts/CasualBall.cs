using UnityEngine;
using CasualBase;

public class CasualBall : MonoBehaviour {
    private CasualSoundManager soundManager;
    private static float INITIAL_GRAVITY = 0.1f;
    public static Vector2 INITIAL_SPEED = new Vector2 (100f, 100f);
    public static Vector2 INITIAL_POSITION = new Vector2(0, 0);
    
    private float forceUp = 1.02f;
    private int maxSpeed = 20;
    private int timesSpeededUp = 0;
    private float gravityScale = INITIAL_GRAVITY;
    private Rigidbody2D rigidBody;
    private Transform otherTransform;
    
    void Start(){
        soundManager = CasualSoundManager.getInstance();
        GameObject otherObject = GameObject.Find(Constants.SCENE_OBJECTS.CAMERA);
        otherTransform = otherObject.transform;
        rigidBody = gameObject.GetComponent<Rigidbody2D> ();
    }
    void FixedUpdate(){
        float dist = Vector3.Distance(otherTransform.position, transform.position);
        print (dist);
        if (dist > 13) {
            //Out of screen.
            this.reset ();
        }
    }
    private void speedUp(){
        if(timesSpeededUp < maxSpeed){
            timesSpeededUp++;
            gravityScale *= forceUp;
        }
    }
    public void reset(){
        rigidBody.velocity = new Vector2 (1f, 1f);
        transform.position = INITIAL_POSITION;
        gravityScale = INITIAL_GRAVITY;
        //timesSpeededUp = 0;
    }
    void Update(){
        if (rigidBody.velocity.y < 0) {
            rigidBody.gravityScale = gravityScale;
        } else if (rigidBody.velocity.y > 0){
            rigidBody.gravityScale = -gravityScale;
        }
    }
    void OnCollisionEnter2D(Collision2D collider){
        speedUp ();
        
        soundManager.playSound(CasualSoundManager.SFX.JUMP);
    }
}
