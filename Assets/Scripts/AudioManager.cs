using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    [HideInInspector] public AudioSource BackgroundMusic1;             // Pre-declaring variables for the different music the game has
    [HideInInspector] public AudioSource BackgroundMusic2;      //
    [HideInInspector] public AudioSource MainMenuMusic;         //

    public AudioSource[] AudioSources;      // Array for all the audiosource objects

    [Space(15)]
    public Slider MasterVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SfxVolumeSlider;

    public static AudioManager Instance;    // Using the singleton pattern

    public void Awake()
    {
        if (Instance == null) { Instance = this; }
    }
    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic1 = GameObject.Find("WaveMusic").GetComponent<AudioSource>();                   // Gets references to all of the AudioSource components
        BackgroundMusic2 = GameObject.Find("GracePeriodMusic").GetComponent<AudioSource>();     //
        MainMenuMusic = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();           //

        BackgroundMusic1.loop = true;              // Turns the looping on all of the audios on
        BackgroundMusic2.loop = true;       // This means that when the audio ends it will start playing again
        MainMenuMusic.loop = true;          //

        MasterVolumeSlider.value = GlobalVariables.Instance.masterVolume;
        MusicVolumeSlider.value = GlobalVariables.Instance.musicVolume;
        SfxVolumeSlider.value = GlobalVariables.Instance.sfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        //Kutsu t�ss� change music volume
       // ChangeMusicVolume();
    }
    public void FadeMusic(AudioSource _newAudio, AudioSource _oldAudio)
    {
        _oldAudio.DOFade(0, 0.75f).OnComplete(() => _oldAudio.enabled = false); // Fades the old music away and when the volume is 0 it disables the AudioSource
        _newAudio.enabled = true;       // Enables the new music
        _newAudio.volume = 0;           // Sets it volume to 0 so it can faded in

        _newAudio.Play();               // Starts playing the audio
        _newAudio.DOFade(GlobalVariables.Instance.masterVolume, 1f);        // Fades the new music in , first param is the target volume and second is the time which it fades in (seconds)
    }

    public AudioSource GetCurrentAudio()
    {
        AudioSource currAudio;      // Local variable where we will store the music thats currently playing
        for (int i = 0; i < AudioSources.Length; i++)   // Loops trough all the audiosources
        {
            if (AudioSources[i].enabled)
            {                                   // If the audiosource at i is enabled it will return it as currAudio
                currAudio = AudioSources[i];
                return currAudio;
            }
        }
        return null;    // Incase there is no audio currently playing
    }

    public void ChangeMusicVolume()
    {
        GlobalVariables.Instance.masterVolume = MasterVolumeSlider.value;
        GlobalVariables.Instance.musicVolume = MusicVolumeSlider.value;
        GlobalVariables.Instance.sfxVolume = SfxVolumeSlider.value;

        GetCurrentAudio().DOFade(GlobalVariables.Instance.masterVolume * GlobalVariables.Instance.musicVolume, 0f);
    }
}
