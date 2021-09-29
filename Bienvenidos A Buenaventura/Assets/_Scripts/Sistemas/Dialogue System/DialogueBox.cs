using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D;

namespace DialogueSystem
{
    public class DialogueBox : MonoBehaviour
    {
        public GameObject playerDialogueBox;
        public TextMeshProUGUI playerDialogueTxt;

        public GameObject npcDialogueBox;
        public TextMeshProUGUI npcDialogueTxt;

        public TextMeshProUGUI npcName;
        public Image npcImage;
        public SpriteAtlas spriteAtlas;

        public Animator npcAnimator;
        public Animator boxAnimator;

        public GameObject previousButton;
        public Image previousButtonEffect;

        public GameObject nextButton;
        public Image nextButtonEffect;
    }
}