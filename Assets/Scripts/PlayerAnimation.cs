using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    Idle,
    Run,
    Jump,
    Fall,
    Ground
}

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    public Animator Animator { get; set; }
    public PhysicsBehaviour PhysicsBehaviour { get; set; }
    public AnimationState CurrentAnimationState { get; set; }

    private void Awake()
    {
        if (!Animator)
            Animator = GetComponent<Animator>();
        if (!PhysicsBehaviour)
            PhysicsBehaviour = GetComponent<PhysicsBehaviour>();
    }

    private void OnEnable()
    {
        PhysicsBehaviour.GroundCollisionEnterNotify += OnGroundedCollisionEnter;
        PhysicsBehaviour.OnStartRunningNotify += StartRunBehaviour;
        PhysicsBehaviour.OnStopRunningNotify += StopRunBehaviour;
    }

    private void OnDisable()
    {
        PhysicsBehaviour.GroundCollisionEnterNotify -= OnGroundedCollisionEnter;
        PhysicsBehaviour.OnStartRunningNotify -= StartRunBehaviour;
        PhysicsBehaviour.OnStopRunningNotify -= StopRunBehaviour;
    }

    private void OnGroundedCollisionEnter(Collision2D collision)
    {
        
    }

    private void StartRunBehaviour()
    {
        Animator.SetBool("isRunning", true);
    }

    private void StopRunBehaviour()
    {
        Animator.SetBool("isRunning", false);
    }
}
 