using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] private float loadingTime = 3f;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;        
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());            
        }        
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(loadingTime);
        LoadNextScene();
    }

    public void LoadOptionsMenu()
    {        
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {        
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLoserScreen()
    {
        SceneManager.LoadScene("Loser Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
