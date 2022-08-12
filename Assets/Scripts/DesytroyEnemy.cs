using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Quest.Enemies {
    public class DesytroyEnemy : MonoBehaviour
    {
        [SerializeField] private int health = 5;
        
        void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }

        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Mine"))
            {
                health -= 1;


            }
        }

    }

}