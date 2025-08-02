using UnityEngine;

public class SceneMusicStarter : MonoBehaviour
{
    public string musicName = "menumusic";

    private void Start()
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.PlayMusic(musicName);
    }
}
