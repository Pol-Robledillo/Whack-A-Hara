using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;

    public static MusicManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MusicManager>();
                if (_instance == null)
                {
                    GameObject musicManagerObject = new GameObject("MusicManager");
                    _instance = musicManagerObject.AddComponent<MusicManager>();
                    DontDestroyOnLoad(musicManagerObject);
                }
            }
            return _instance;
        }
    }

    public AudioSource music;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Asegurarse de que el AudioSource esté presente en todas las escenas
        if (music == null)
        {
            music = GetComponent<AudioSource>();
            if (music == null)
            {
                music = gameObject.AddComponent<AudioSource>();
            }
        }

        // Configurar el AudioSource
        music.loop = true;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            music.clip = clip;
            music.Play();
        }
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void SetVolume(float volume)
    {
        music.volume = Mathf.Clamp(volume, 0f, 1f);
    }
}
