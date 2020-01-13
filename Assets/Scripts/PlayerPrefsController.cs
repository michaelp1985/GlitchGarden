using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";    
    const float MAX_VOLUME = 1f;
    const float MIN_VOLUME = 0f;

    const string DIFFICULTY_KEY = "difficulty";
    const int MAX_DIFFICULTY = 10;
    const int MIN_DIFFICULTY = 1;

    const string ATTACKER_HEALTH_KEY = "attacker health";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Master volume is out of range.");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(int health)
    {
        PlayerPrefs.SetInt(ATTACKER_HEALTH_KEY, health);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetInt(ATTACKER_HEALTH_KEY);
    }
}
