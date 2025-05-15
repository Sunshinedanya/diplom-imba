using System.Collections.Generic;
using Dialog.Model;
using Interactable;
using UnityEngine;
using UnityEngine.UI;

namespace Dialog.System
{
    public class SimpleDialogueManager : MonoBehaviour, IInteractable
    {
        public GameObject optionButtonPrefab;
        public Transform optionsContainer;

        private Dictionary<string, DialogueNode> dialogue = new Dictionary<string, DialogueNode>();
    
        private void Start()
        {
            SetupDialogue();
        }

        private void SetupDialogue()
        {
            dialogue["start"] = new DialogueNode("Привет! Как дела?", "1", new List<DialogueOption>
            {
                new DialogueOption("Всё хорошо.", "good"),
                new DialogueOption("Так себе.", "bad")
            });

            dialogue["good"] = new DialogueNode("Рад слышать!", "1");
            dialogue["bad"] = new DialogueNode("Печально. Надеюсь, всё наладится.", "1");
        }

        private void ShowNode(string nodeId)
        {
            if (dialogue.TryGetValue(nodeId, out var node) == false) return;

            DialogueController.instance.NewDialogueInstance(node.Response, node.CharacterId);
            ClearOptions();

            foreach (var option in node.Options)
            {
                GameObject btn = Instantiate(optionButtonPrefab, optionsContainer);
                btn.GetComponentInChildren<Text>().text = option.responses;
                btn.GetComponent<Button>().onClick.AddListener(() => ShowNode(option.NextNodeId));
            }
        }

        private void ClearOptions()
        {
            foreach (Transform child in optionsContainer)
            {
                Destroy(child.gameObject);
            }
        }

        public void Interact()
        {
            ShowNode("start");
        }

        public string GetDescription()
        {
            return "Поговорить";
        }
    }

}