using UnityEngine;

public class CellphoneInteraction : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void NextScene()
    { 
        animator.Play("Celular_Sai");
    }
}
