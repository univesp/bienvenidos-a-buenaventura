using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomActionChoices : MonoBehaviour
{
    [SerializeField] private UnityEvent roomActions;
    [SerializeField] private UnityEvent endActions;

    [SerializeField] private int actionsQtd;
    private int currentActionsDone = 0;

    public void ActionDone()
    {
        currentActionsDone++;
    }

    public void CheckActions()
    {
        if(currentActionsDone == actionsQtd)
        {
            endActions.Invoke();
        }
        else
        {
            roomActions.Invoke();
        }
    }
}
