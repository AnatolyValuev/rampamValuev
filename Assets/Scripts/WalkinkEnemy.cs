using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkinkEnemy : MonoBehaviour
{

    //[RequireComponent(typeof(NavMeshAgent))]

    private NavMeshAgent agent;
    private Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent >();
        player = FindObjectOfType<Quest.Enemies. PlayerRun>().transform;
    }


    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
