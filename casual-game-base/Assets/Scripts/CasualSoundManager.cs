using UnityEngine;
using System.Collections;

public class CasualSoundManager : MonoBehaviour {
	private static CasualSoundManager musicPlayer;

	private bool muted = false; //TODO: Load this from the last configuration if any.
	
	public AudioSource backgroundAudio;
	public AudioSource gameOverAudio;

	public AudioSource jumpAudio;  
	public AudioSource runAudio;  
	public AudioSource successAudio;
	public AudioSource defaultAudio;

	
	public enum SFX { JUMP, RUN, SUCCESS };
	public enum MUSIC { BACKGROUND, GAME_OVER };

	/**
	 * Fancy way to call CasualSoundManager.musicPlayer
	 * If this is null, it is because it has been destroyed from a different source.
	 * */
	public static CasualSoundManager getInstance(){
		return CasualSoundManager.musicPlayer;
	}
	
	/**
	 * Singleton hack for our music manager.
	 * 
	 * Yes, this sux.
	 **/
	void Awake(){
		GameObject currentGameObject = transform.gameObject;
		if (CasualSoundManager.musicPlayer != null) {
			//Already have one? Destroy this (loaded from a different scene)
			Destroy (currentGameObject);
		} else {
			//First time here? Record it to prevent creation of more.
			CasualSoundManager.musicPlayer = this;

			//With this the object is not going to be destroyed while jumping scenes.
			//If this is in your root, you are safe, however if this is inside a wrapper, then the wrapper still can be destroyed.
			//DontDestroyOnLoad (currentGameObject);
			GameObject parent = currentGameObject.transform.parent.gameObject;
			//Careful with adding more stuff to the parent as they won't get destroyed!
			DontDestroyOnLoad (parent); 
		}
	}

	public void mutePressed(){
		muted = false;

		//Make sure you silence all your current songs and long SFX if any
		backgroundAudio.Pause ();
	}
	
	public void unmutePressed(){
		muted = true;

		//Check if you should resume any audio source such as background?
		backgroundAudio.Play();
	}

	/**
	 * Useful to play some sounds from a predefined list of effects.
	 * param sound The SFX to play
	 * @see  enum SFX
	 * */
	public void playSound(CasualSoundManager.SFX sound){
		switch(sound){
			//Add more SFX as declared in your enum
			case SFX.JUMP:
				jumpAudio.Play();
			break;
			case SFX.RUN:
				runAudio.Play();
				break;
			case SFX.SUCCESS:
				successAudio.Play();
				break;
			default:
				defaultAudio.Play ();
				break;
		}
	}

	/**
	 * Plays a song, sets its value to loop or stops it.
	 * @param song: The song to be played from your enum mapped here to your audio sources.
	 * @param play: if it has to be played or stopped.
	 * */

	public void manageSong(CasualSoundManager.MUSIC song, bool play, bool loop){
		if(muted){
			return;
		}
		AudioSource audio = null;
		switch(song){
			//Add more MUSIC as declared in your enum
			case MUSIC.BACKGROUND:
				audio = backgroundAudio;
				break;
			case MUSIC.GAME_OVER:
				audio = gameOverAudio;
				break;
			default:
				audio = defaultAudio;
				break;
		}
		if(audio != null){
			audio.loop = loop;
			if(play){
				audio.Play ();
			} else {
				audio.Stop();
			}
		}
	}
	public void manageSong(CasualSoundManager.MUSIC song, bool play){
		this.manageSong (song, true, true);
	}
	public void playSong(CasualSoundManager.MUSIC song){
		this.manageSong (song, true);
	}
	public void stopSong(CasualSoundManager.MUSIC song){
		this.manageSong (song, false);
	}
}
