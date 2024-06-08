using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class VolumeSetting : MonoBehaviour
{
    
    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioMixer myMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }else
        {
            SetMusicVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
}
