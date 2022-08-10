using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Quest.Enemies
{
    public class SoundDoor : MonoBehaviour
    {

       // public AudioClip soo;
       // private AudioSource audioo;
      //  private void Start()
       // {
         //   audioo = GetComponent<AudioSource>();
       // }


        [SerializeField] private GameObject soundDoor;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                 soundDoor.SetActive(true);
                //audioo.PlayOneShot(soo);
            }
           else
            {
                soundDoor.SetActive(false);
            }
            
            
            
        
            
        
    }
    }
}