﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State[] states;
    [SerializeField] private State currentState;
    private Dictionary<Type, State> stateDictionary = new Dictionary<Type, State>();
    
    protected virtual void Awake()
    {
        foreach (State state in states)
        {
            State instance = Instantiate(state);
            instance.Initialize(this);
            stateDictionary.Add(instance.GetType(), instance);
            if(currentState == null)
            {
                currentState = instance;
            }
        }
        currentState.Enter();
    }

    public void Transition<T>() where T : State
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    protected void Update()
    {
        currentState.HandleUpdate();
    }
}
