using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FXManager : MonoBehaviour {

    public AudioClip Bounce;
    public AudioClip PowerUpGreen;
    public AudioClip PowerUpRed;
    public AudioClip ClickUI;
    public AudioClip ClickUI2;
    public AudioClip Win;
    public AudioClip Die;
    private AudioSource source;
    public static FXManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        source.volume = PlayerPrefs.GetFloat("FX volume", 1);

    }
    public void PlayBounce()
    {
        source.PlayOneShot(Bounce, source.volume);

    }
    public void PlayPowerGreen()
    {
        source.PlayOneShot(PowerUpGreen, source.volume);

    }
    public void PlayPowerRed()
    {
        source.PlayOneShot(PowerUpRed, source.volume);

    }
    public void PlayWin()
    {
        source.PlayOneShot(Win, source.volume);
    }
    public void PlayDie()
    {
        source.PlayOneShot(Die, source.volume);
    }

    public void PlayUIClick()
    {
        source.PlayOneShot(ClickUI, source.volume);
    }

    public void PlayUIClickBack()
    {
        source.PlayOneShot(ClickUI2, source.volume);
    }

}