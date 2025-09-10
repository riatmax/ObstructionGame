using UnityEngine;
using UnityEngine.SceneManagement;
public class MainScreenManager : MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(0);
    }
    public void tutorialButton()
    {
        SceneManager.LoadScene(2);
    }
    public void goBackButton()
    {
        SceneManager.LoadScene(1);
    }
    public void restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
