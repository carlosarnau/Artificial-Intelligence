using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    public float freq = 0f;
    public float turnSpeed = 0.0f;
    public float movSpeed = 0.0f;
    public float acceleration = 0.1f;
    public float turnAcceleration = 0.1f;
    public float maxSpeed = 10.0f;
    public float maxTurnSpeed = 2.0f;

    Quaternion rotation;
    Vector3 movement;

    float stopDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }

    void Seek()
    {
        agent.destination = target.transform.position;
    }
}