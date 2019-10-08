using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Continue()
    {
        SceneManager.LoadScene("MainScene");
        Debug.Log("Continue");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
