using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TMP_Text liveDisplayer;

    private void Update()
    {
        liveDisplayer.text = PlayerStats.Lives.ToString() + " LIVES";
    }
}
