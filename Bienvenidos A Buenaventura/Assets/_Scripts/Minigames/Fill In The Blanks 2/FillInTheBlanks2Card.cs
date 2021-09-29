using UnityEngine;
using TMPro;
using System.Collections;

public class FillInTheBlanks2Card : MonoBehaviour
{
    [SerializeField] private FillInTheBlanks2 fillInTheBlanksCore;
    [SerializeField] private TextMeshProUGUI cardWord;
    public int index;

    [SerializeField] private GameObject frases;
    [SerializeField] private GameObject botoes;

    [SerializeField] private Animator animator;

    public void InsertWord()
    {
        fillInTheBlanksCore.ChangeButtonText(cardWord.text);
        fillInTheBlanksCore.SetUsedCard(this);
        
        StartCoroutine(WaitToActivate());        
    }

    private IEnumerator WaitToActivate()
    {
        yield return new WaitForSeconds(0.01f);
        frases.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        frases.SetActive(true);
        gameObject.SetActive(false);

        animator.Play("EspaçoBranco_Sai");
    }
}
