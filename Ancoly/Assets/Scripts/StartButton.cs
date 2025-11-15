using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Name der Spielszene (genau wie im Project)
    public string gameSceneName = "MainScene";

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
