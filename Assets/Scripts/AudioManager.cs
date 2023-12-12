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


    public static AudioManager Instance;    // Using the singleton pattern

    public void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(this); }
    }
    // Start is called before the first frame update
    void Start()
    {
        getSlider();

        BackgroundMusic1 = transform.Find("BackgroundMusic1").GetComponent<AudioSource>();                   // Gets references to all of the AudioSource components
      //  BackgroundMusic2 = GameObject.Find("BackgroundMusic2").GetComponent<AudioSource>();     //
       // MainMenuMusic = GameObject.Find("MainMenuMusic").GetComponent<AudioSource>();           //

        BackgroundMusic1.loop = true;              // Turns the looping on all of the audios on
        BackgroundMusic2.loop = true;       // This means that when the audio ends it will start playing again
        MainMenuMusic.loop = true;          //

        MasterVolumeSlider.value = GlobalVariables.Instance.masterVolume;


        FadeMusic(BackgroundMusic1, BackgroundMusic1);
    }

    // Update is called once per frame
    void Update()
    {
       ChangeMusicVolume();
        if(MasterVolumeSlider == null) { getSlider(); }
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


        GetCurrentAudio().DOFade(GlobalVariables.Instance.masterVolume, 0f);
    }

    public void getSlider()
    {
        // Find all sliders
        Slider[] sliders = Resources.FindObjectsOfTypeAll<Slider>();

        // Find the slider with the specific tag
        Slider mySlider = null;
        foreach (Slider slider in sliders)
        {
            if (slider.gameObject.tag == "volumeslider")
            {
                mySlider = slider;
                break;
            }
        }

        MasterVolumeSlider = mySlider;
    }
}
