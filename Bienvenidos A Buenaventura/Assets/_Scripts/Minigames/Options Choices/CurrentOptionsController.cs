using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Esse script define quais botões de opção o botão de opção atual vai pressionar
public class CurrentOptionsController : MonoBehaviour {
    
    [SerializeField] private OptionActionController[] optionsAction;
    [SerializeField] private Button[] button;
    [SerializeField] private TextMeshProUGUI[] buttonText;

    [SerializeField] private Animator animator;

    //Isso é chamado pelo dialogue holder
    #region Set Current Options
    public void SetCurrentOption1(OptionActionController _currentOptionAction)
    {
        animator.Play("gameplay_alternativas_entra");
        optionsAction[0] = _currentOptionAction;
        buttonText[0].text = optionsAction[0].optionText;
        button[0].gameObject.SetActive(true);
    }

    public void SetCurrentOption2(OptionActionController _currentOptionAction)
    {
        optionsAction[1] = _currentOptionAction;
        buttonText[1].text = optionsAction[1].optionText;
        button[1].gameObject.SetActive(true);
    }

    public void SetCurrentOption3(OptionActionController _currentOptionAction)
    {
        optionsAction[2] = _currentOptionAction;
        buttonText[2].text = optionsAction[2].optionText;
        button[2].gameObject.SetActive(true);
    }
    #endregion

    #region METHODS THE OPTIONS BUTTONS WILL CALL WHEN PRESSED
    public void PressButton1()
    {
        optionsAction[0].CallOptionAction();
        DisableButtons();
    }

    public void PressButton2()
    {
        optionsAction[1].CallOptionAction();
        DisableButtons();
    }

    public void PressButton3()
    {
        optionsAction[2].CallOptionAction();
        DisableButtons();
    }
    #endregion

    public void DisableButtons()
    {
        for(int i = 0; i < 3; i++)
        {
            if(optionsAction[i] != null)
            {
                optionsAction[i] = null;
                button[i].gameObject.SetActive(false);
            }
        }
    }
}
