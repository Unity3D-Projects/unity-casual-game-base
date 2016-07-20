using UnityEngine;
using System.Collections;

public class CasualSoundController : MonoBehaviour {
	CasualSoundManager manager;
	void Start(){
		manager = CasualSoundManager.getInstance ();
	}

	public void mutePressed(){
		manager.mute ();
	}

	public void unmutePressed(){
		manager.unmute();
	}
}
