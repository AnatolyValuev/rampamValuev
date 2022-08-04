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
       
        void Start()
        {
            navMeshAgent.SetDestination(waypoints[0].position);

        }

       
        void Update()
        {
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                index = (index + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[index].position);
            }
        }
    }
}