using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected MoveSystem _moveSystem;

    public virtual void Start(MoveSystem moveSystem)
    {
        _moveSystem = moveSystem;
    }

    public virtual void Move()
    {

    }

}
