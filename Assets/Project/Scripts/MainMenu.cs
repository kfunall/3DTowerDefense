using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string levelToLoad = "PlayScene";
    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}