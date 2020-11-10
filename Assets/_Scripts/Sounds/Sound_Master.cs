using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class Sound_Master : MonoBehaviour
{
    public AudioMixer mixer;
    private int FirstTimeInt = 0;
    private static readonly string MasterPref = "MasterPref";
    private static readonly string FirstTime = "FirstTime";

    private void Awake()
    {
        if(FirstTimeInt == 0)
        {
            mixer.SetFloat("Master", 1f);
            PlayerPrefs.SetFloat(MasterPref, 1f);
            PlayerPrefs.SetInt(FirstTime, -1);
        }
        else
        {
            mixer.SetFloat("Master", PlayerPrefs.GetFloat(MasterPref));
        }
    }

    public void setlevel(float sliderValue)
    {
        mixer.SetFloat("Master", Mathf.Log10 (sliderValue) *20);
    }
}
