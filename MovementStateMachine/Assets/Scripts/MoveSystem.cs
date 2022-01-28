using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : StateMachine
{
    [SerializeField]
    private Vector2 targetPosition;

    private Vector2 velocity = Vector2.zero;

    private Vector2 desiredVelocity = Vector2.zero;

    private Vector2 steering = Vector2.zero;

    private Vector2 targetDistance = Vector2.zero;

    [Range(3.0f, 6.0f)]
    [SerializeField]
    private float speed;

    [SerializeField]
    [Range(1.0f, 2.0f)]
    private float nearUmbral;

    [SerializeField]
    [Range(5.0f, 10.0f)]
    private float farUmbral;

    public Vector2 Velocity { get => velocity; set => velocity = value; }
    public Vector2 DesiredVelocity { get => desiredVelocity; set => desiredVelocity = value; }
    public Vector2 Steering { get => steering; set => steering = value; }

    public void OnNearTarget()
    {
        SetState(new Flee());
    }

    public void OnFarTarget()
    {
        SetState(new Seek());
    }

    public override void SetState(State state)
    {
        base.SetState(state);
        state.Start(this);
    }

    private void Start()
    {
        SetState(new Seek());
    }

    private void Update()
    {
        targetDistance = (targetPosition - (Vector2)transform.position);

        DesiredVelocity = targetDistance.normalized * speed;

        if (targetDistance.magnitude >= farUmbral)
            OnFarTarget();

        if (targetDistance.magnitude <= nearUmbral)
            OnNearTarget();

        _state.Move();
    }
}
