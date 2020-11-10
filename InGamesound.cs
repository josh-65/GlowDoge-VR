using UnityEngine.UI;
using UnityEngine;

public class InGamesound : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SfxPref = "SfxPref";
    private static readonly string VoicePref = "VoicePref";
    private int firstPlayInt;
    public Slider musicSlider, sfxSlider, voiceSlider;
    private float musicFloat, sfxFloat, voiceFloat;
    public AudioSource MusicAudio;
    public AudioSource[] SfxAudio;
    public AudioSource[] VoiceAudio;
    

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            musicFloat = 0.8f;
            sfxFloat = 1f;
            voiceFloat = 1f;
            musicSlider.value = musicFloat;
            sfxSlider.value = sfxFloat;
            voiceSlider.value = voiceFloat;
            PlayerPrefs.SetFloat(MusicPref, musicFloat);
            PlayerPrefs.SetFloat(SfxPref, sfxFloat);
            PlayerPrefs.SetFloat(VoicePref, voiceFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicPref);
            sfxFloat = PlayerPrefs.GetFloat(SfxPref);
            voiceFloat = PlayerPrefs.GetFloat(VoicePref);
            musicSlider.value = musicFloat;
            sfxSlider.value = sfxFloat;
            voiceSlider.value = voiceFloat;
        }
    }

    public void SaveSoundSettings()
    {
            PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
            PlayerPrefs.SetFloat(SfxPref, sfxSlider.value);
            PlayerPrefs.SetFloat(VoicePref, voiceSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        MusicAudio.volume = musicSlider.value;
        for(int i = 0; i < SfxAudio.Length; i++)
        {
            SfxAudio[i].volume = sfxSlider.value;
        }
        
        for(int i = 0; i < VoiceAudio.Length; i++)
        {
            VoiceAudio[i].volume = voiceSlider.value;
        }
    }

}