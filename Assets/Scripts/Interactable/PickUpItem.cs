using UnityEngine;

namespace Interactable
{
    public class PickUpItem : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Player.Player.instance.ArtCount += 1;
            gameObject.SetActive(false);
        }

        public string GetDescription()
        {
            return "Подобрвть артефакт";
        }
    }
}