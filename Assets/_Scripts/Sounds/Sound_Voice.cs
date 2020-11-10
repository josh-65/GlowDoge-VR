using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class Sound_Voice : MonoBehaviour
{
    public AudioMixer mixer;
    private int FirstTimeInt = 0;
    private static readonly string VoicePref = "VoicePref";
    private static readonly string FirstTime = "FirstTime";

    private void Awake()
    {
        if(FirstTimeInt == 0)
        {
            mixer.SetFloat("Voice", 1f);
            PlayerPrefs.SetFloat(VoicePref, 1f);
            PlayerPrefs.SetInt(FirstTime, -1);
        }
        else
        {
            mixer.SetFloat("Voice", PlayerPrefs.GetFloat(VoicePref));
        }
    }

    public void setlevel(float sliderValue)
    {
        mixer.SetFloat("Voice", Mathf.Log10 (sliderValue) *20);
    }
}
