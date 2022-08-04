using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDoor : MonoBehaviour
{
    [SerializeField] private GameObject soundDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundDoor.SetActive(true);
        }
        else
        {
            soundDoor.SetActive(false);
        }

    }
}
