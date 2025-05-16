using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        private void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            
            instance = this;
        }

        public int ArtCount { private set; get; }
        public bool HasKeys{ private set; get; }

        public UnityEvent<int> ArtAdded;
        public UnityEvent<bool> GotKey;

        public void KeyPickUp()
        {
            HasKeys = true;
            
            GotKey.Invoke(HasKeys);
        }

        public void ArtefactPickUp()
        {
            ArtCount++;
            
            ArtAdded.Invoke(ArtCount);
        }
    }
}