using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    public GameObject levelCompleteUI;
    public string nextLevelName;
    public string mainMenuName;
    public bool isComplete = false;
    public AudioSource levelMusic;
    public AudioSource levelCompletedMusic;
    private bool isLevelScene = false;
    private void Start()
    {
        isLevelScene = SceneManager.GetActiveScene().name.StartsWith("Level");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isComplete = true;
            Time.timeScale = 0f;
            levelCompleteUI.SetActive(true);
            levelMusic.Stop();
            levelCompletedMusic.Play();
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Level"))
        {
            isLevelScene = true;
            levelMusic.volume = 1f;
        }
        else
        {
            isLevelScene = false;
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1f;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
        Time.timeScale = 1f;
    }
    public void RetryLevel()
    {
        isComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
