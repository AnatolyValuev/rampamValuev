using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Quest.Enemies
{

    public class PatrolEnemy : MonoBehaviour
    {

        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Transform[] waypoints;
        private int index;
       // [SerializeField] private float distance;
        [SerializeField] private Transform player;
        private NavMeshAgent agent;
       // private bool boolAgro;
        void Start()
        {
            navMeshAgent.SetDestination(waypoints[0].position);
            agent = GetComponent<NavMeshAgent>();
        }

      
       
        void Update()
        {
           Patrol();
            
            Agro();
        }


        private void Patrol()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                index = (index + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[index].position);
            }
        }

        private void Agro()
        {
            float distance = Vector3.Distance(transform.position, player.position);


            if (distance <= 10 )
            {
                agent.SetDestination(player.position);
                //boolAgro = true;
            }
            //else
           // {
               //boolAgro = false;
           // }

            
        }

    }
}