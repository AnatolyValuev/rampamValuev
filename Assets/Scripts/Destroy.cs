using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
   // [SerializeField] private GameObject mine;
    [SerializeField] private float timeDestroy = 1f;
  //  [SerializeField] private ParticleSystem _game;


    void Update()
    {


        Destroy(gameObject,timeDestroy);
      
       
    }
 

}
