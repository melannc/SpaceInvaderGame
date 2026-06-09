using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // singleton so any script can access it

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip bgmClip;
    public AudioClip shootClip;
    public AudioClip gameOverClip;
    public AudioClip enemyDestroyClip;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void PlayShoot()
    {
        sfxSource.PlayOneShot(shootClip);
    }

    public void PlayGameOver()
    {
        StopBGM();
        sfxSource.PlayOneShot(gameOverClip);
    }

    public void PlayEnemyDestroy()
    {
        sfxSource.PlayOneShot(enemyDestroyClip);
    }
}