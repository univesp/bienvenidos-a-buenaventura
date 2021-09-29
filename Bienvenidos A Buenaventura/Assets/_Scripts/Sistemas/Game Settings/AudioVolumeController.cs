using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//Esse script recebe o slider da opção de controle dos volumes. Precisa criar um audio mixer com o "BGMVolume" e o "SFXVolume", e deixar ambos expostos
public class AudioVolumeController : MonoBehaviour {

    [SerializeField] private AudioMixer masterMixer;

    [Header("BGM")]
    [SerializeField] private Slider bgmSlider;

    [Header("SFX")]
    [SerializeField] private Slider sfxSlider;

    //Variável auxiliar para pegar o valor do mixer
    private float value;

    //Inicia o slider na última posição deixada pelo jogador
    private void OnEnable()
    {
        if(masterMixer.GetFloat("BGMVolume", out value))
        {
            bgmSlider.value = value;
        }

        if (masterMixer.GetFloat("SFXVolume", out value))
        {
            sfxSlider.value = value;
        }
    }

    public void ChangeBGMVolume()
    {
        masterMixer.SetFloat("BGMVolume", bgmSlider.value);
    }

    public void ChangeSFXVolume()
    {
        masterMixer.SetFloat("SFXVolume", sfxSlider.value);
    }
}
