using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Quest.Enemies 
{
    


public class ShootingEnemy : MonoBehaviour
{

        
        [SerializeField] private GameObject prefabBullet;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnStep = 1f;
        private float nextSpawnTime;

        [SerializeField] private float angularSpeed = 1f;

        private Transform player;

        private void Start()
        {
            player = FindObjectOfType<Quest.Enemies.PlayerRun>().transform;
        }


        private void Update()
    {
            Shoot();
            LookAtPlayer();



    }
        private void LookAtPlayer()
        {
            var direction = player.transform.position - transform.position;
            var rotation = Vector3.RotateTowards(transform.forward, direction, angularSpeed * Time.deltaTime,0f);
            transform.rotation = Quaternion.LookRotation(rotation);

            
        }
        private void Shoot()
        {
            if (Time.time > nextSpawnTime)
            {
                Instantiate(prefabBullet, spawnPoint.position, spawnPoint.rotation);
                nextSpawnTime = Time.time * spawnStep;
            }
        }
}
}