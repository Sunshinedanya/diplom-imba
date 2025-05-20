using Interactable;
using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public AudioSource audios;

    private void Awake()
    {
        audios = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        var hasKeys = Player.Player.instance.HasKeys;

        if (hasKeys == false)
        {
            DialogueController.instance.NewDialogueInstance("Дверь заперта, где то должен быть ключ");
            audios.Play();
        }
        else
        {
            //TODO Open door
            gameObject.SetActive(false);
        }
    }

    public string GetDescription()
    {
        return "Открыть дверь";
    }
}
 