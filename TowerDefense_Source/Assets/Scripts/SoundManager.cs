using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip sound;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    public Sound[] effectSoundLists;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("\'SoundManager\' 컴포넌트를 포함한 \'GameObject\'가 존재하지 않습니다.");
        }
        instance = this;
    }

    public void PlaySoundEffect(string _name)
    {
        for (int i = 0; i < effectSoundLists.Length; i++)
        {
            if (_name == effectSoundLists[i].name)
            {
                audioSource.clip = effectSoundLists[i].sound;
                audioSource.Play();
            }
        }
    }
}
