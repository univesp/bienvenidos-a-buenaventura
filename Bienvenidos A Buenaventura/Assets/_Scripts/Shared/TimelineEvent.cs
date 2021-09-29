using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class TimelineEvent : MonoBehaviour
{
    private void OnEnable()
    {
        if (playOnAwake)
        {
            timeline.time = 0;
            StartCoroutine(WaitAnimationTransition(0));
        }
    }

    //Esse script pega referência de uma timeline e espera o tempo total (ou parcial) da animação para trocar para a próxima tela
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private UnityEvent actions;
    [SerializeField] private bool playOnAwake;
    [SerializeField] private bool haveDelay;
    [SerializeField] private UnityEvent postDelayActions;

    public void PlayTimeline(float hasteTime)
    {
        StartCoroutine(WaitAnimationTransition(hasteTime));
    }

    private IEnumerator WaitAnimationTransition(float hasteTime)
    {
        timeline.Play();
        //O "hasteTime" adianta a troca das telas antes da animação acabar
        yield return new WaitForSeconds((float)timeline.duration - hasteTime);
        actions.Invoke();

        if (haveDelay)
        {
            //Se tiver adiantar o tempo na espera anterior, se desconta esse tempo aqui. Assim a tela atual não desativa antes do término da animação
            yield return new WaitForSeconds(hasteTime);
            postDelayActions.Invoke();
        }
    }
}