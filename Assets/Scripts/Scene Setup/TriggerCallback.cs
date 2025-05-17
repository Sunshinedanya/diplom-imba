using UnityEngine;
using UnityEngine.Events;

public class TriggerCallback : MonoBehaviour
{
    public UnityEvent<Collider> OnTriggered;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggered.Invoke(other);
    }
}
