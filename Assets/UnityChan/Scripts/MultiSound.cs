using UnityEngine;
using System.Collections;

public class MultiSound : MonoBehaviour {

	// define the audio clips: 
	public AudioClip clipStart;
	public AudioClip clipStart2;
	public AudioClip clipRun;		
	public AudioClip clipWin;
	public AudioClip clipLost;
    public AudioClip clipExplosion;
    public AudioClip clipBGM;
	
	private AudioSource audioStart;
	private AudioSource audioStart2;
	private AudioSource audioRun;
	private AudioSource audioWin;
	private AudioSource audioLost;
    private AudioSource audioExplosion;
    private AudioSource audioBGM;
		
	private bool is_play_child;
	
	AudioSource AddAudio(AudioClip clip){
		AudioSource newAudio = gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip;
		return newAudio;
	}
	
	void Awake(){
		// add the necessary AudioSources:
		audioStart = AddAudio(clipStart);
		audioStart2 = AddAudio(clipStart2);
		audioRun = AddAudio(clipRun);
		audioRun.loop = true;
		audioWin = AddAudio(clipWin);
		audioLost = AddAudio(clipLost);
        audioExplosion = AddAudio(clipExplosion);
        audioBGM = AddAudio(clipBGM);
		is_play_child = false;        
	}
	
	// Use this for initialization
	void Start () {
		audioStart.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!is_play_child){
			if (audioStart.isPlaying){
				// do nothing
			} else {
				is_play_child = true;
				audioStart2.PlayDelayed(1f);
                audioBGM.loop = true;
                audioBGM.volume = 0.3f;
                audioBGM.PlayDelayed(3.08f);               
			}
		}        
	}
	
	public void SetRun(bool isrun){
		if (isrun) audioRun.Play();
		else audioRun.Stop();
	}	
	
	public void Win(){
		audioWin.Play();
	}
	
	public void Lost(){
		audioLost.Play();
	}

    public void Explosion()
    {
        audioExplosion.Play();
    }
}
