using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOnClickOrKey : MonoBehaviour
{
    [SerializeField]
    private string sceneName = ""; // Name der Zielszene. Leer lassen, um stattdessen die nächste Szene in der Build-Liste zu laden.

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            var currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
