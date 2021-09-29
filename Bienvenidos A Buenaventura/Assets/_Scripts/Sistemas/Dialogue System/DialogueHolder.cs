using UnityEngine;
using UnityEngine.Events;

//Esse script faz a leitura do json e guarda os dados. Ele tem um custom editor.
namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        [Header("JSON")]
        public TextAsset json;

        [Header("Elementos do diálogo")]
        public DialogoRoot dialogue;

        //Avisa que esse diálogo vai ativar ações quando ele terminar
        public bool haveAction;
        [Header("Ações")]
        public UnityEvent action;

        private void Start()
        {
            if (json != null)
            {
                LoadJson();
            }
        }

        //Carrega o Json
        private void LoadJson()
        {
            dialogue = JsonUtility.FromJson<DialogoRoot>(json.text);
        }
    }
}