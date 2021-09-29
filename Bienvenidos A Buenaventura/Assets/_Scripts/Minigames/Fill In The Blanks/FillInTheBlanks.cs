using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class FillInTheBlanks : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown[] blankBox;
    [SerializeField] private int[] answer;

    [SerializeField] private UnityEvent correctAction;
    private bool isCorrect = true;

    [SerializeField] private Color rightColor;
    [SerializeField] private Color wrongColor;
    [SerializeField] private Color normalColor;

    [SerializeField] AudioClip rightSound;
    [SerializeField] AudioClip wrongSound;

    public void CheckBlankBox()
    {
        for(int i = 0; i < blankBox.Length; i++)
        {
            if (blankBox[i].value != answer[i])
            {
                blankBox[i].image.color = wrongColor;
                isCorrect = false;
            }
            else
            {
                blankBox[i].image.color = rightColor;
            }
        }

        StartCoroutine(ChangeBoxColor());
    }

    private IEnumerator ChangeBoxColor()
    {
        if (isCorrect)
        {
            AudioPlayerController.instance.PlaySFX(rightSound);
        }
        else
        {
            AudioPlayerController.instance.PlaySFX(wrongSound);
        }

        yield return new WaitForSeconds(1.0f);

        for(int i = 0; i < blankBox.Length; i++)
        {
            blankBox[i].image.color = normalColor;
        }

        if (isCorrect)
        {
            correctAction.Invoke();
        }  
        else
        {
            isCorrect = true;
        }
    }
}
