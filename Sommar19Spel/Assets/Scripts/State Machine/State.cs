using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : ScriptableObject
{
    public virtual void Initialize(StateMachine owner) { }
    public virtual void Enter() { }
    public virtual void HandleUpdate() { }
    public virtual void Exit() { }

}
