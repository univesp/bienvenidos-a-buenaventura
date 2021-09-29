using UnityEngine;
using UnityEngine.Events;

public class StartActions : MonoBehaviour
{
    [SerializeField] private UnityEvent startActions;

    private void OnEnable()
    {
        startActions.Invoke();
    }
}