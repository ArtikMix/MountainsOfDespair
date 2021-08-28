using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{

    Transform target;       
    public static NavMeshAgent agent;
    public float[] pos;
    public float[] rot;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pos = new float[3];
        rot = new float[3];

    }

    void Update()
    {
        if (target != null)
        {    
            agent.SetDestination(target.position);
            FaceTarget();
        }
        pos[0] = agent.transform.position.x;
        pos[1] = agent.transform.position.y;
        pos[2] = agent.transform.position.z;
        rot[0] = agent.transform.rotation.x;
        rot[1] = agent.transform.rotation.y;
        rot[2] = agent.transform.rotation.z;
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
