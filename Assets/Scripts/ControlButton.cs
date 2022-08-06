using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Quest.Enemies
{

    public class ControlButton : MonoBehaviour
    {
        [SerializeField] private GameObject soundDoor;
        [SerializeField] private ControlObjects controlObjects;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out PlayerRun player))
            {
                controlObjects.Activate();
                soundDoor.SetActive(true);
            }
            else
            {
                soundDoor.SetActive(false);
            }
         
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Quest.Enemies. PlayerRun player))
            {
                controlObjects.Deactivate();
                soundDoor.SetActive(true);
            }
            else
            {
                soundDoor.SetActive(false);
            }
        }
    }
}