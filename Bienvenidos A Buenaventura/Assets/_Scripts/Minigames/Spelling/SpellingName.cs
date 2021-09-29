using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SpellingName : MonoBehaviour
{
    private string playerName;
    private List<string> spelledName = new List<string>();

    private List<string> playerSpelling = new List<string>();
    [SerializeField] private TextMeshProUGUI spelledText;

    [SerializeField] private UnityEvent correctAction;
    private bool isCorrect = true;

    [SerializeField] AudioClip rightSound;
    [SerializeField] AudioClip wrongSound;

    private bool canPressButton = true;
    [SerializeField] private GameObject okButton;

    private void Start()
    {
        playerName = PlayerPrefs.GetString("Sobrenome", "Santos");
        playerName = playerName.ToLower();

        for(int i = 0; i < playerName.Length; i ++)
        {
            switch(playerName[i])
            {
                case 'a':
                    spelledName.Add("a");
                    break;

                case 'b':
                    spelledName.Add("be");
                    break;

                case 'c':
                    if(playerName[i + 1] == 'h')
                    {
                        spelledName.Add("che");
                        i++;
                    }
                    else
                    {
                        spelledName.Add("ce");
                    }
                    break;

                case 'd':
                    spelledName.Add("de");
                    break;

                case 'e':
                    spelledName.Add("e");
                    break;

                case 'f':
                    spelledName.Add("efe");
                    break;

                case 'g':
                    spelledName.Add("ge");
                    break;

                case 'h':
                    spelledName.Add("hache");
                    break;

                case 'i':
                    spelledName.Add("i");
                    break;

                case 'j':
                    spelledName.Add("jota");
                    break;

                case 'k':
                    spelledName.Add("ka");
                    break;

                case 'l':
                    if(playerName[i + 1] == 'l')
                    {
                        spelledName.Add("elle");
                        i++;
                    }
                    else
                        spelledName.Add("ele");
                    break;

                case 'm':
                    spelledName.Add("eme");
                    break;

                case 'n':
                    spelledName.Add("ene");
                    break;

                case 'o':
                    spelledName.Add("o");
                    break;

                case 'p':
                    spelledName.Add("pe");
                    break;

                case 'q':
                    spelledName.Add("cu");
                    break;

                case 'r':
                    if(playerName[i + 1] == 'r')
                    {
                        spelledName.Add("doble erre");
                        i++;
                    }
                    else
                    {
                        spelledName.Add("erre");
                    }
                    break;

                case 's':
                    spelledName.Add("ese");
                    break;

                case 't':
                    spelledName.Add("te");
                    break;

                case 'u':
                    spelledName.Add("u");
                    break;

                case 'v':
                    spelledName.Add("uve");
                    break;

                case 'w':
                    spelledName.Add("uve doble");
                    break;

                case 'x':
                    spelledName.Add("equis");
                    break;

                case 'y':
                    spelledName.Add("ye");
                    break;

                case 'z':
                    spelledName.Add("zeta");
                    break;
            }
        }
    }

    public void InputSpell(string _spell)
    {
        if (canPressButton)
        {
            playerSpelling.Add(_spell);

            if (playerSpelling.Count == 1)
            {
                spelledText.text = playerSpelling[0];
            }
            else
            {
                spelledText.text += string.Format(" - {0}", playerSpelling[playerSpelling.Count - 1]);
            }

            if (playerSpelling.Count >= spelledName.Count)
            {            
                okButton.SetActive(true);
                canPressButton = false;
            }
        }
    }

    public void DeleteSpelledLetter()
    {        
        if (playerSpelling.Count > 0)
        {
            playerSpelling.RemoveAt(playerSpelling.Count - 1);

            spelledText.text = "";
            for (int i = 0; i < playerSpelling.Count; i++)
            {
                if (i == 0)
                {
                    spelledText.text = playerSpelling[0];
                }
                else
                {
                    spelledText.text += string.Format(" - {0}", playerSpelling[i]);
                }
            }

            if (!canPressButton)
            {
                okButton.SetActive(false);
                canPressButton = true;
            }
        }
    }

    public void CompareLists()
    {
        for(int i = 0; i < spelledName.Count; i++)
        {
            if(spelledName[i] != playerSpelling[i])
            {
                isCorrect = false;
            }
        }

        if(isCorrect)
        {
            AudioPlayerController.instance.PlaySFX(rightSound);
            correctAction.Invoke();
        }
        else
        {
            AudioPlayerController.instance.PlaySFX(wrongSound);
            isCorrect = true;
        }
    }
}
