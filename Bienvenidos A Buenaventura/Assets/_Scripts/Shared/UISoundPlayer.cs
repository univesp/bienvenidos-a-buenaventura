using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISoundPlayer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private AudioClip mouseEnter;
    [SerializeField] private AudioClip mouseClick;

    private bool isSelected;

    private void Update()
    {
        if(isSelected)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                AudioPlayerController.instance.PlaySFX(mouseClick);
            }
        }
    }    

    public void OnPointerEnter(PointerEventData eventData)
    {
        isSelected = true;
        AudioPlayerController.instance.PlaySFX(mouseEnter);
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        AudioPlayerController.instance.PlaySFX(mouseEnter);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelected = false;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }
}
