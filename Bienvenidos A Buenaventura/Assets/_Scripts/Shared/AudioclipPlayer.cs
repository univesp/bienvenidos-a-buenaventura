using UnityEngine;

public class AudioclipPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public void PlayAudio()
    {
        AudioPlayerController.instance.PlaySFX(audioClip);
    }
}
