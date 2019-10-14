using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public void Select(string _level)
    {
        fader.FadeTo(_level);
    }
}
