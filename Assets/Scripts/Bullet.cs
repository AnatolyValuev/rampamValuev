using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage = 5f;
    
        void Update()
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Hit(collision.gameObject);
        }


        private void Hit(GameObject collisionGO)
        {
            if(collisionGO.TryGetComponent(out HealthMan health))
            {
                health.Hit(damage);
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            Hit(other.gameObject);
        }

    }
}