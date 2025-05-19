using Interactable;
using UnityEngine;

public class MirrorInteract : MonoBehaviour, IInteractable
{
    private bool broken = false;

    [SerializeField] private GameObject _mirror;
    
    public void Interact()
    {
    }

    public string GetDescription()
    {
        if(broken != false)
            return "";
        
        return "";
    }

    private void BreakGlass()
    {
    }
}
