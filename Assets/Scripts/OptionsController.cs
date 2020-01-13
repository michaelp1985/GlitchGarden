using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultyslider;
    [SerializeField] float defaultVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        var startVolume = PlayerPrefsController.GetMasterVolume();
        volumeSlider.value = (startVolume != 0) ? startVolume : defaultVolume;
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultyslider.value);
    }

    public void SetDefaults()
    {
        //PlayerPrefsController.SetMasterVolume(defaultVolume);
        volumeSlider.value = defaultVolume;
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();

        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found.");
        }
    }
}
