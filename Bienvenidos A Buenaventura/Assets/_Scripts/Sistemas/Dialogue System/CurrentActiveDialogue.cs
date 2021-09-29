using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class CurrentActiveDialogue : MonoBehaviour
    {
        [HideInInspector]
        public DialogueHolder activeDialogue;
        private int dialogueIndex = 0;
        private int falaIndex = 0;

        public DialogueBox dialogueBox;

        public bool canInteract;

        [SerializeField] private GameObject optionsScreen;
        [SerializeField] private GameObject nextButton;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canInteract && !optionsScreen.activeSelf)
            {
                CallNextDialogue();
            }
        }

        public void SetActiveIntecaction(bool _currentState)
        {
            canInteract = _currentState;
        }

        public void CallNextDialogue()
        {            
            if (dialogueBox.gameObject.activeSelf)
            {
                nextButton.SetActive(true);
                if (activeDialogue.dialogue.dialogo[dialogueIndex].fala.Length > falaIndex)
                {
                    if (!activeDialogue.dialogue.dialogo[dialogueIndex].jogadorFala)
                    {
                        dialogueBox.playerDialogueBox.SetActive(false);
                        dialogueBox.npcDialogueBox.SetActive(true);
                        dialogueBox.npcDialogueTxt.text = activeDialogue.dialogue.dialogo[dialogueIndex].fala[falaIndex];

                        dialogueBox.npcName.text = activeDialogue.dialogue.dialogo[dialogueIndex].nomePersonagem;

                        dialogueBox.npcImage.sprite = dialogueBox.spriteAtlas.GetSprite(activeDialogue.dialogue.dialogo[dialogueIndex].expressao);
                        dialogueBox.npcImage.SetNativeSize();
                    }
                    else
                    {
                        dialogueBox.playerDialogueBox.SetActive(true);
                        dialogueBox.playerDialogueTxt.text = activeDialogue.dialogue.dialogo[dialogueIndex].fala[falaIndex];
                    }
                    falaIndex++;
                }
                else
                {
                    falaIndex = 0;
                    dialogueIndex++;
                    if (activeDialogue.dialogue.dialogo.Length > dialogueIndex)
                    {
                        if (activeDialogue.dialogue.dialogo[dialogueIndex].animacaoTroca)
                        {
                            StartCoroutine(SwitchAnimation());
                        }
                        else
                        {
                            CallNextDialogue();
                        }
                    }
                    else
                    {
                        dialogueIndex = 0;
                        canInteract = false;
                        nextButton.SetActive(false);
                        if (activeDialogue.haveAction)
                        {
                            activeDialogue.action.Invoke();
                        }
                        else
                        {
                            dialogueBox.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        public void CallPreviousDialogue()
        {
            if (falaIndex > 0)
            {
                falaIndex--;
                if (!activeDialogue.dialogue.dialogo[dialogueIndex].jogadorFala)
                {
                    dialogueBox.playerDialogueBox.SetActive(false);
                    dialogueBox.npcDialogueBox.SetActive(true);
                    dialogueBox.npcDialogueTxt.text = activeDialogue.dialogue.dialogo[dialogueIndex].fala[falaIndex];

                    dialogueBox.npcName.text = activeDialogue.dialogue.dialogo[dialogueIndex].nomePersonagem;

                    dialogueBox.npcImage.sprite = dialogueBox.spriteAtlas.GetSprite(activeDialogue.dialogue.dialogo[dialogueIndex].expressao);
                    dialogueBox.npcImage.SetNativeSize();
                }
                else
                {
                    dialogueBox.playerDialogueBox.SetActive(true);
                    dialogueBox.playerDialogueTxt.text = activeDialogue.dialogue.dialogo[dialogueIndex].fala[falaIndex];
                }
            }
            else
            {
                dialogueIndex--;
                if (dialogueIndex >= 0)
                {
                    falaIndex = activeDialogue.dialogue.dialogo[dialogueIndex].fala.Length;
                    CallPreviousDialogue();
                }
                else
                {
                    //DESLIGAR O BOTAO DE VOLTAR
                }
            }
        }

        public void SetActiveDialogue(DialogueHolder _dialogueHolder)
        {
            activeDialogue = _dialogueHolder;
            ReplaceKeyWords();
        }

        public void CloseDialogueBox()
        {
            dialogueBox.npcDialogueBox.SetActive(false);
            dialogueBox.playerDialogueBox.SetActive(false);
            dialogueBox.gameObject.SetActive(false);
        }

        //Troca todas as palavras chaves da fala pelas palavras corretas
        private void ReplaceKeyWords()
        {
            for (int i = 0; i < activeDialogue.dialogue.dialogo.Length; i++)
            {
                for (int j = 0; j < activeDialogue.dialogue.dialogo[i].fala.Length; j++)
                {
                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("SOBRENOME"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("SOBRENOME", PlayerPrefs.GetString("Sobrenome", "Santos"));
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("NOME"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("NOME", PlayerPrefs.GetString("Nome", "Fulano"));
                    }
                    
                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("ESTADO"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("ESTADO", PlayerPrefs.GetString("Estado"));
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("BRASILEIRO"))
                    {
                        if (PlayerPrefs.GetInt("Genero", 1) == 0)
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("BRASILEIRO", "brasileño");
                        }
                        else
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("BRASILEIRO", "brasileña");
                        }
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("SENHOR"))
                    {
                        if (PlayerPrefs.GetInt("Genero", 1) == 0)
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("SENHOR", "señor");
                        }
                        else
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("SENHOR", "señora");
                        }
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("BEM-VINDO"))
                    {
                        if (PlayerPrefs.GetInt("Genero", 1) == 0)
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("BEM-VINDO", "Bienvenido");
                        }
                        else
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("BEM-VINDO", "Bienvenida");
                        }
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("SR"))
                    {
                        if (PlayerPrefs.GetInt("Genero", 1) == 0)
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("SR", "Sr.");
                        }
                        else
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("SR", "Sra.");
                        }
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("SÓ"))
                    {
                        if (PlayerPrefs.GetInt("Genero", 1) == 0)
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("SÓ", "solo");
                        }
                        else
                        {
                            activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("SÓ", "sola");
                        }
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("DIAFUTURO"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("DIAFUTURO", PlayerPrefs.GetString("DiaFuturo", "05"));
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("DIA"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("DIA", PlayerPrefs.GetString("DiaAtual", "01"));
                    }

                    if(activeDialogue.dialogue.dialogo[i].fala[j].Contains("QUARTO"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("QUARTO", PlayerPrefs.GetString("Quarto", "Exterior"));
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("OBJETO1"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("OBJETO1", PlayerPrefs.GetString("Objeto1", "caja fuerte"));
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("OBJETO2"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("OBJETO2", PlayerPrefs.GetString("Objeto2", "ducha"));
                    }

                    if (activeDialogue.dialogue.dialogo[i].fala[j].Contains("OBJETO3"))
                    {
                        activeDialogue.dialogue.dialogo[i].fala[j] = activeDialogue.dialogue.dialogo[i].fala[j].Replace("OBJETO3", PlayerPrefs.GetString("Objeto3", "secador de pelo"));
                    }
                }
            }
        }

        private IEnumerator SwitchAnimation()
        {
            canInteract = false;
            //FAZER A CHAMADA DA ANIMAÇÃO DE TROCA
            yield return new WaitForSeconds(0);            
            CallNextDialogue();
            canInteract = true;
        }
    }
}