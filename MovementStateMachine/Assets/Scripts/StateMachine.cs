using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class StateMachine: MonoBehaviour
{
    protected State _state;

    public virtual void SetState(State state)
    {
        _state = state;
    }
}
