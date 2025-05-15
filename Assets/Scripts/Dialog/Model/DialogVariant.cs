using System;
using System.Collections.Generic;

namespace Dialog.Model
{
    [Serializable]
    public class DialogVariant
    {
        public List<string> responses;
    }
    
    [Serializable]
    public class DialogueOption
    {
        public string responses;
        public string NextNodeId;

        public DialogueOption(string responses, string nextId)
        {
            this.responses = responses;
            NextNodeId = nextId;
        }
    }
    
    [Serializable]
    public class DialogueNode
    {
        public string CharacterId;
        public string Response;
        public List<DialogueOption> Options;

        public DialogueNode(string response, string characterId, List<DialogueOption> options = null)
        {
            Response = response;
            CharacterId = characterId;
            Options = options ?? new List<DialogueOption>();
        }
    }
}