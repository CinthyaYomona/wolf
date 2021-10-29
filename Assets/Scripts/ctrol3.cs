using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ctrol3 : MonoBehaviour
{
    public GameObject target;
    private Animator ani;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        agent.SetDestination(target.transform.position);
        ani.SetFloat("Distancia", dist);
    }
}
