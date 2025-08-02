using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Ses Efektleri")]
    public AudioClip click;
    public AudioClip dead;
    public AudioClip boom;
    public AudioClip powerup;
    public AudioClip putbomb;
    public AudioClip victory;

    [Header("Müzikler")]
    public AudioClip gamemusic;
    public AudioClip menumusic;

    private AudioSource sfxSource;
    private AudioSource musicSource;

    private string currentMusicName = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            sfxSource = gameObject.AddComponent<AudioSource>();
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Efekt çal
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    // Efekt ismiyle çal
    public void PlaySFX(string name)
    {
        switch (name)
        {
            case "click": PlaySFX(click); break;
            case "dead": PlaySFX(dead); break;
            case "boom": PlaySFX(boom); break;
            case "powerup": PlaySFX(powerup); break;
            case "putbomb": PlaySFX(putbomb); break;
            case "victory": PlaySFX(victory); break;
        }
    }

    // Müzik çal
    public void PlayMusic(AudioClip music)
    {
        if (musicSource.clip == music) return;
        musicSource.clip = music;
        musicSource.Play();
    }

    // Müzik ismiyle çal
    public void PlayMusic(string name)
    {
        if (currentMusicName == name && musicSource.isPlaying)
            return; // Ayný müzik zaten çalýyor, tekrar baþlatma

        switch (name)
        {
            case "gamemusic":
                musicSource.clip = gamemusic;
                currentMusicName = "gamemusic";
                break;
            case "menumusic":
                musicSource.clip = menumusic;
                currentMusicName = "menumusic";
                break;
            default:
                musicSource.clip = null;
                currentMusicName = "";
                break;
        }

        if (musicSource.clip != null)
        {
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            musicSource.Stop();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
        currentMusicName = "";
    }
}