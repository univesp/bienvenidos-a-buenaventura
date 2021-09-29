using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransitionAnimationEvent : MonoBehaviour
{
    public Animator transitionAnimator;

    public UnityEvent transitionSequence;
    [SerializeField] UnityEvent postTransitionSequence;

    [SerializeField] bool havePostTransition;

    public void CallTransition(float transitionTime)
    {
        StartCoroutine(TransitionSequence(transitionTime));
    }

    private IEnumerator TransitionSequence(float time)
    {
        transitionAnimator.Play("EnterTransition");
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(transitionAnimator.GetCurrentAnimatorStateInfo(0).length);
        transitionSequence.Invoke();
        yield return new WaitForSeconds(time);        
        if(havePostTransition)
        {
            postTransitionSequence.Invoke();
        }
        transitionAnimator.Play("ExitTransition");        
    }
}
