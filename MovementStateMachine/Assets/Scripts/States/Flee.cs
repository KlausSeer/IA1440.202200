using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : State
{
    public override void Move()
    {
        _moveSystem.Steering = _moveSystem.Velocity - _moveSystem.DesiredVelocity;
        _moveSystem.Velocity += _moveSystem.Steering * Time.deltaTime;
        _moveSystem.gameObject.transform.position += (Vector3)_moveSystem.Velocity * Time.deltaTime;
    }
}
