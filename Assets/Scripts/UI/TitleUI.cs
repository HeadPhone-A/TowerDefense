using UnityEngine;

public class TitleUI : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo("LevelSelectScene");
    }

    public void Continue()
    {
        Debug.Log("Continue");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
