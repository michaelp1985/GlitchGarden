using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int attackerCount = 0;
    bool isTimeOver = false;
    bool isLevelComplete = false;
    [SerializeField] float waitToLoad = 4f;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AddAttacker()
    {
        attackerCount++;
    }

    public void RemoveAttacker()
    {
        attackerCount--;
    }

    public void LevelTimerComplete()
    {
        this.isTimeOver = true;
        StopSpawners();
    }

    public bool isLevelOver()
    {
        return isTimeOver;
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach(var spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLevelComplete)
        {
            if (isTimeOver && attackerCount <= 0)
            {
                isLevelComplete = true;
                StartCoroutine(HandleWinCondition());                
            } 
        }
    }
}
