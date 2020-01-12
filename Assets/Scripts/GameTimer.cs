using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds.")]
    [SerializeField] float levelTime = 10;
    LevelController levelController;
    bool triggerLevelFinished = false;

    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    void Update()
    {
        if (triggerLevelFinished) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        triggerLevelFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (triggerLevelFinished)
        {            
            levelController.LevelTimerComplete();            
        }
    }
}
