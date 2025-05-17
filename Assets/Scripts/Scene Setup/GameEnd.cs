using System;
using System.Collections.Generic;
using Interactable;
using UnityEngine;

namespace Scene_Setup
{
    public class GameEnd : MonoBehaviour, IInteractable
    {
        [SerializeField] private List<GameObject> artefacts;

        private bool _ritualStarted;
        
        private void StartRitual()
        {
            _ritualStarted = true;
            
            foreach (var artefact in artefacts)
            {
                artefact.SetActive(true);
            }
        }

        public void OnTrigger(Collider other)
        {
            if(_ritualStarted == false)
                return;
            
            var isPlayer = other.gameObject.CompareTag("Player");
            
            if(isPlayer == false)
                return;
            
            Debug.Log(other.gameObject.name);
        }

        public void Interact()
        {
            StartRitual();
        }

        public string GetDescription()
        {
            return "Начать Ритуал";
        }
    }
}