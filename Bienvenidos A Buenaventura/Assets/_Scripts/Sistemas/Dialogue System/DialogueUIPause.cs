using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DialogueSystem;

public class DialogueUIPause : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] CurrentActiveDialogue currentDialogue;

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentDialogue.SetActiveIntecaction(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        currentDialogue.SetActiveIntecaction(true);
    }

    public void OnSelect(BaseEventData eventData)
    {
        currentDialogue.SetActiveIntecaction(false);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        currentDialogue.SetActiveIntecaction(true);
    }
}