using System.Collections;
using UnityEngine;

//Esse script vai em todos os objetos que iniciam um diálogo
namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField]
        private CurrentActiveDialogue activeDialogue;

        public DialogueHolder dialogueHolder;

        public bool playOnAwake;

        private void OnEnable()
        {
            if (playOnAwake)
            {
                StartDialogueWithDelay(1.0f);
            }
        }

        //Atualiza o Dialogue Holder desse objeto. O Dialogue Holder é o script que contém o Json
        public void SetDialogueHolder(DialogueHolder _dialogueHolder)
        {
            dialogueHolder = _dialogueHolder;
        }

        //Define o diálogo atual e inicia as falas
        public void StartDialogue()
        {
            activeDialogue.SetActiveDialogue(dialogueHolder);
            activeDialogue.dialogueBox.gameObject.SetActive(true);
            activeDialogue.CallNextDialogue();
            activeDialogue.canInteract = true;
        }        

        //Atualiza o Dialogue Holder e já inicia a fala
        public void SetDialogueAndStart(DialogueHolder _dialogueHolder)
        {
            dialogueHolder = _dialogueHolder;
            activeDialogue.SetActiveDialogue(dialogueHolder);
            activeDialogue.dialogueBox.gameObject.SetActive(true);
            activeDialogue.CallNextDialogue();
            activeDialogue.canInteract = true;
        }

        public void StartDialogueWithDelay(float _time)
        {
            StartCoroutine(DialogueDelay(_time));
        }

        private IEnumerator DialogueDelay(float _time)
        {
            yield return new WaitForSeconds(_time);
            StartDialogue();
        }
    }
}