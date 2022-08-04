using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{

    public class HealthMan : MonoBehaviour
    {
        [SerializeField] private float maHealth = 100f;
        [SerializeField] private float curHealth;

        private void Awake()
        {
            curHealth = maHealth;
        }

        public void Hit(float damage)
        {
            curHealth -= damage;
            if(curHealth <= 0)
            {
                Time.timeScale = 0;
            }
        }
    }
}