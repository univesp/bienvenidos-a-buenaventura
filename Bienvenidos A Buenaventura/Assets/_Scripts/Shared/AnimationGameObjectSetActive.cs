using UnityEngine;

public class AnimationGameObjectSetActive : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    public void SetThisActive()
    {
        targetObject.SetActive(true);
    }

    public void SetThisInactive()
    {
        targetObject.SetActive(false);
    }
}
