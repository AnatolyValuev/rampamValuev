using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Enemies
{
    public class EnemySpawn : MonoBehaviour
    {

        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float spawnStep = 1f;
        [SerializeField] private const float LifeTime = .5f;
         
        [SerializeField] private float nextSpawnTime;



        void Update()
        {

            if (Time.time > nextSpawnTime)
            {
                var enemy = Instantiate(enemyPrefab, transform);
                nextSpawnTime = Time.time + spawnStep;
                Destroy(enemy.gameObject, LifeTime);
            }

        }
    }
}