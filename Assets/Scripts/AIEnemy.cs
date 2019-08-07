using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIEnemy : MonoBehaviour
{

    [SerializeField] AudioSource audioSrcWalk;
    Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        // Update destination if the target moves one unit
        if(agent.isActiveAndEnabled)
        {
            if (Vector3.Distance(destination, target.position) > 1.0f)
            {
                destination = target.position;
                agent.destination = destination;
            }

            if(!agent.isStopped)
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
        }
        
    }
    //below methods are called in the run animation
    public void StartWalkSound()
    {
        audioSrcWalk.Play();
    }
    public void StopWalkSound()
    {
        audioSrcWalk.Stop();
    }
    
}
