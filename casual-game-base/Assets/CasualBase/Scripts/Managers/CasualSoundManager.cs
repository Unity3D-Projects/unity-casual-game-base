using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CasualSoundManager {
	private static CasualSoundManager self = null;

	private CasualSoundManager(){ 
		//Build Audio Sources.
		m_songsAudioClipList = new Dictionary<MUSIC, AudioClip> ();
		m_SFXAudioSourceList = new Dictionary<SFX, AudioSource> ();
		m_songAudioSource = getNewAudioSource ();
	}

	public static CasualSoundManager getInstance(){
		if (CasualSoundManager.self == null) {
			CasualSoundManager.self = new CasualSoundManager();
		}
		return CasualSoundManager.self;
	}

	private bool muted = false; //TODO: Load this from the last configuration if any.

	public enum SFX { DEFAULT, JUMP, SUCCESS };
	public enum MUSIC { BACKGROUND, GAME_OVER };

	private AudioSource m_songAudioSource;

	[System.NonSerialized]
	public Dictionary<MUSIC, AudioClip> m_songsAudioClipList;

	[System.NonSerialized]
	public Dictionary<SFX, AudioSource> m_SFXAudioSourceList;

	private const int SONGS_LIST_SIZE = 2;
	private const int SFX_LIST_SIZE = 1;

	public void setSongs(AudioClip[] audioClipList){
		if(audioClipList == null || audioClipList.Length < SONGS_LIST_SIZE){
			throw new MissingReferenceException ("SONGS List has to be: (" + SONGS_LIST_SIZE + ")" );
		}
		m_songsAudioClipList.Add (MUSIC.BACKGROUND, audioClipList [0]);
		m_songsAudioClipList.Add (MUSIC.GAME_OVER, audioClipList [1]);

		//immediatly plays background song
		this.playSong (MUSIC.BACKGROUND);
	}


	public void setSFX(AudioClip[] audioClipList){
		if(audioClipList == null || audioClipList.Length < SFX_LIST_SIZE){
			throw new MissingReferenceException ("SFX List has to be: (" + SFX_LIST_SIZE + ")" );
		}

		m_SFXAudioSourceList.Add (SFX.DEFAULT, getNewAudioSource (audioClipList [0]));
		m_SFXAudioSourceList.Add (SFX.JUMP, getNewAudioSource (audioClipList [1]));
		m_SFXAudioSourceList.Add (SFX.SUCCESS, getNewAudioSource (audioClipList [2]));
	}


	private AudioSource getNewAudioSource(){
		return this.getNewAudioSource (null);
	}
	private AudioSource getNewAudioSource(AudioClip clip){
		AudioSource newAudioSource = SoundsBucketController.getInstance ().getNewAudioSource ();
		newAudioSource.clip = clip;
		return newAudioSource;
	}


	public void mute(){
		muted = true;
		//Make sure you silence all your current songs and long SFX if any
		pauseAudio (m_songAudioSource);
	}

	public void unmute(){
		muted = false;
		//Check if you should resume any audio source such as background?
		playAudio(m_songAudioSource);
	}

	/**
	 * Useful to play some sounds from a predefined list of effects.
	 * param sound The SFX to play
	 * @see  enum SFX
	 * */
	public void playSound(CasualSoundManager.SFX sound){
		//TODO: Add Default Sound for nulls;
		AudioSource audioSFX;
		bool found = m_SFXAudioSourceList.TryGetValue (sound, out audioSFX);
		if (!found) {
			return;
		}
		playAudio (audioSFX);
	}

	/**
	 * Plays a song, sets its value to loop or stops it.
	 * @param song: The song to be played from your enum mapped here to your audio sources.
	 * @param play: if it has to be played or stopped.
	 * */

	public void manageSong(CasualSoundManager.MUSIC song, bool play, bool loop){
		//Can only have 1 song at the time.
		stopAudio(m_songAudioSource);

		//Assigning the clip from the songs pool.
		AudioClip audioClip;
		bool found = m_songsAudioClipList.TryGetValue (song, out audioClip);

		if (!found) {
			return;
		}

		m_songAudioSource.loop = loop;
		m_songAudioSource.clip = audioClip;

		if(play){
			playAudio (m_songAudioSource);
		}
	}
	public void playAudio(AudioSource audio){
		if(muted){
			return;
		}
		if (audio != null) {
			audio.Play ();
		}
	}
	public void pauseAudio(AudioSource audio){
		if (audio != null) {
			audio.Pause();
		}
	}
	public void stopAudio(AudioSource audio){
		if (audio != null) {
			audio.Stop();
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
	public void stopSong(){
		stopAudio (m_songAudioSource);
	}
	public void playSong(){
		playAudio (m_songAudioSource);
	}
}
