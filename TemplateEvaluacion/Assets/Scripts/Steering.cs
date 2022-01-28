using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    [Range(2.0f , 5.0f)]
    [SerializeField]
    private float speed;

    [Range(1.0f, 3.0f)]
    [SerializeField]
    private float slowDownRadius;

    [Range(0.2f, 1.0f)]
    [SerializeField]
    private float slowDownFactor;

    [Range(0.0f, 0.5f)]
    [SerializeField]
    private float stopRadius;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float steeringForce;

    private Vector2 velocity = Vector2.zero;

    private Vector2 targetPosition = Vector2.zero;

    Vector2 Seek(Vector2 desiredVelocity)
    {
        return desiredVelocity - velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 targetPosition = mouseTarget ? Camera.main.ScreenToWorldPoint(Input.mousePosition) : movingTarget.transform.position;

        Vector2 targetDistance = (targetPosition - (Vector2)transform.position);

        Vector2 desiredVelocity = targetDistance.normalized * speed;

        Vector2 steering = Vector2.zero;

        desiredVelocity *= targetDistance.magnitude > slowDownRadius ? 1.0f: slowDownFactor;

        steering = Seek(desiredVelocity);

        steering *= steeringForce;

        steering *= targetDistance.magnitude > stopRadius? 1.0f : 0.0f;

        velocity += steering == Vector2.zero? desiredVelocity.normalized: desiredVelocity * steering;

        transform.position += (Vector3)velocity * Time.deltaTime;

    }
}
