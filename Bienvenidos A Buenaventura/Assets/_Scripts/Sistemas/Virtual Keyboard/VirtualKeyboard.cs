using UnityEngine;
using TMPro;

//Esse script vai na instância do teclado virtual
public class VirtualKeyboard : MonoBehaviour
{
    private TMP_InputField currentInputField;
    [SerializeField] Animator animator;
    private bool isActive;

    public void CallVirtualKeyboard()
    {
        if(!isActive)
        {
            animator.Play("Teclado_Entrada");
            isActive = true;
        }
    }

    public void DismissVirtualKeyboard()
    {
        animator.Play("Teclado_Sai");
        isActive = false;
    }

    public void SetCurrentInputField(TMP_InputField _currentInputField)
    {
        currentInputField = _currentInputField;        
    }

    public void GetLetter(string _letter)
    {                
        //Verifica se é a primeira letra da palavra. Se for, a letra sai maiúscula. Senão, sai minúscula
        if (currentInputField.text == "" || currentInputField.text == null || currentInputField.text.Substring(currentInputField.text.Length - 1) == " ")
        {
            currentInputField.text += _letter.ToUpper();
        }
        else
        {
            currentInputField.text += _letter;
        }
    }

    public void DeleteLetter()
    {        
        //Deleta letra se houver alguma letra no input field
        if (currentInputField.text != "" || currentInputField.text != null)
        {
            currentInputField.text = currentInputField.text.Substring(0, currentInputField.text.Length - 1);
        }
    }
}