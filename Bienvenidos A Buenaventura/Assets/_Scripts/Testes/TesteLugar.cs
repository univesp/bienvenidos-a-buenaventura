using System.Collections;
using UnityEngine;

public class TesteLugar : MonoBehaviour
{
    [SerializeField] private RectTransform layout;
    [SerializeField] private RectTransform button;

    private void Start()
    {
        StartCoroutine(Teste());
    }

    IEnumerator Teste()
    {
        yield return new WaitForEndOfFrame();
        if (button.anchoredPosition.x + button.rect.width / 2 > layout.rect.width)
        {
            Debug.Log("Saiu da área");
            Destroy(gameObject);
        }
    }
}