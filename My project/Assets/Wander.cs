using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seeking : MonoBehaviour
{
    public GameObject target;

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
        if (Vector3.Distance(target.transform.position, transform.position) < stopDistance) return;

        freq += Time.deltaTime;
        if (freq > 0.5)
        {
            freq -= 0.5f;
            Seek();
        }

        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);

        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed * Time.deltaTime;
    }

    void Wander()
    {
        float radius = 2f;
        float offset = 3f;

        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
    }
}