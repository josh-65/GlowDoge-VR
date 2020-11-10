using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class Sound_Music : MonoBehaviour
{
    public AudioMixer mixer;
    private int FirstTimeInt = 0;
    private static readonly string MusicPref = "MusicPref";
    private static readonly string FirstTime = "FirstTime";

    private void Awake()
    {
        if(FirstTimeInt == 0)
        {
            mixer.SetFloat("Music", 0.7f);
            PlayerPrefs.SetFloat(MusicPref, 0.7f);
            PlayerPrefs.SetInt(FirstTime, -1);
        }
        else
        {
            mixer.SetFloat("Music", PlayerPrefs.GetFloat(MusicPref));
        }
    }

    public void setlevel(float sliderValue)
    {
        mixer.SetFloat("Music", Mathf.Log10 (sliderValue) *20);
        PlayerPrefs.SetFloat(MusicPref, Mathf.Log10 (sliderValue) *20);
    }
}
