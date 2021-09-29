using UnityEngine;

//Esse script pega os Audiosources de efeitos sonoros e música para tocar os sons em outos códigos
public class AudioPlayerController : MonoBehaviour {

    [SerializeField] private AudioSource SFX;
    [SerializeField] private AudioSource BGM;

    public static AudioPlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(AudioClip _clip)
    {
        SFX.PlayOneShot(_clip);
    }

    public void PlayBGM(AudioClip _music)
    {
        BGM.clip = _music;
        BGM.Play();
    }
}