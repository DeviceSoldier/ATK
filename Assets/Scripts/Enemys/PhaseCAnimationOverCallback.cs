using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseCAnimationOverCallback : MonoBehaviour
{
    [SerializeField] private float slowMotion = 0.1f;
    private PhaseCController _controller;
    private Animator _animator;
    
    void Start()
    {
        _controller = GetComponentInParent<PhaseCController>();
        _animator = GetComponent<Animator>();
    }

    public void AnimationOver()
    {
        _controller.AnimationOver();;
    }

    public void EnterSlowMotion()
    {
        _animator.speed = slowMotion;
    }

    public void LeaveSlowMotion()
    {
        _animator.speed = 1.0f;
    }
}
