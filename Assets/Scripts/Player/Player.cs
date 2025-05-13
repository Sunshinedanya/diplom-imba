using UnityEngine;

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
        
        public int ArtCount;
        public bool HasKeys;
    }
}