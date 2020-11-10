using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class Sound_SFX : MonoBehaviour
{
    public AudioMixer mixer;
    private int FirstTimeInt = 0;
    private static readonly string SFXPref = "SFXPref";
    private static readonly string FirstTime = "FirstTime";

    private void Awake()
    {
        if(FirstTimeInt == 0)
        {
            mixer.SetFloat("SFX", 1f);
            PlayerPrefs.SetFloat(SFXPref, 1f);
            PlayerPrefs.SetInt(FirstTime, -1);
        }
        else
        {
            mixer.SetFloat("SFX", PlayerPrefs.GetFloat(SFXPref));
        }
    }

    public void setlevel(float sliderValue)
    {
        mixer.SetFloat("SFX", Mathf.Log10 (sliderValue) *20);
    }
}
