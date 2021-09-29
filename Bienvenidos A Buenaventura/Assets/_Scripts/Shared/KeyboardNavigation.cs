using UnityEngine;
using UnityEngine.UI;

//Esse script permite navegar entre todos os selecionáveis da lista usando apenas o Tab
public class KeyboardNavigation : MonoBehaviour {

    [SerializeField] private Selectable[] selectableObject;

    [SerializeField]private int index = -1;
    private int auxQtd;    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeSelectableSelected();
        }
    }

    //Muda a seleção entre os elementos ativos no array
    private void ChangeSelectableSelected()
    {
        if (CheckActiveSelectables())
        {
            index++;

            if (index >= selectableObject.Length)
            {
                index = 0;
            }

            //Recursão para pular o elemento inativo. Se for ativo, o elemento é selecionado
            if (!selectableObject[index].isActiveAndEnabled || !selectableObject[index].interactable)
            {
                ChangeSelectableSelected();
            }
            else
            {
                selectableObject[index].Select();
            }
        }
    }

    //Checa o array de selecionáveis e retorna verdadeiro se houver algum ativo
    private bool CheckActiveSelectables()
    {
        for(int i = 0; i < selectableObject.Length; i++)
        {
            if(selectableObject[i].isActiveAndEnabled)
            {
                return true;
            }            
        }
        return false;
    }

    //Ativa ou desativa o script 
    public void SetActive(bool value)
    {
        enabled = value;
    }
}