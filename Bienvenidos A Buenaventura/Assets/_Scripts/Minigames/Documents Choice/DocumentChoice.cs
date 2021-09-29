using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DocumentChoice : MonoBehaviour
{
    [SerializeField] private Toggle[] documents;
    [SerializeField] private Toggle[] paymentMethods;

    [SerializeField] private UnityEvent correctAction;
    [SerializeField] private UnityEvent wrongAction;

    public void CheckBoxes()
    {
        if(documents[0].isOn && paymentMethods[1].isOn)
        {
            correctAction.Invoke();
        }
        else
        {
            wrongAction.Invoke();
        }
    }
}
