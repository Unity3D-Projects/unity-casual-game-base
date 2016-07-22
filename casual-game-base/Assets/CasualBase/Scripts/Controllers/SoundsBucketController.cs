using UnityEngine;
using System.Collections;
using CasualBase;
using System.Collections.Generic;

/**
 * Undestroyable object that loads from the very first scene.
 * */
public class SoundsBucketController : MonoBehaviour {
	private static SoundsBucketController self;
	GameObject m_soundsBucketObject;
	public static SoundsBucketController getInstance(){
		if (SoundsBucketController.self == null) {
			throw new MissingComponentException (Constants.EXCEPTION_MESSAGE.NO_BASE);
		}
		return SoundsBucketController.self;
	}

	public GameObject m_audioSourcePrefab;

	[SerializeField]
	private AudioClip[] m_songsList;
	
	[SerializeField]
	private AudioClip[] m_SFXList;

	/**
	 * Singleton hack for our base controller.
	 **/
	void Awake(){
		GameObject currentGameObject = transform.gameObject;
		if (SoundsBucketController.self != null) {
			//Already have one? Destroy this (loaded from a different scene)
			Destroy (currentGameObject);
		} else {
			//First time here? Record it to prevent creation of more.
			SoundsBucketController.self = this;
			m_soundsBucketObject = currentGameObject;

			CasualSoundManager manager = CasualSoundManager.getInstance ();
			manager.setSFX (m_SFXList);
			manager.setSongs (m_songsList);
			
			//With this the object is not going to be destroyed while jumping scenes.
			//If this is in your root, you are safe, however if this is inside a wrapper, then the wrapper still can be destroyed.
			DontDestroyOnLoad (currentGameObject);
		}
	}
	public AudioSource getNewAudioSource(){
		GameObject instance = Instantiate (m_audioSourcePrefab);
		AudioSource audioSource = instance.GetComponent<AudioSource> ();
		instance.transform.parent = m_soundsBucketObject.transform;
		return audioSource;
	}
}
