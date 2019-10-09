using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo("MainScene");
    }

    public void Continue()
    {
        sceneFader.FadeTo("MainScene");
        Debug.Log("Continue");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
