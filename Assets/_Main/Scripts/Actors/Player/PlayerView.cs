using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private Animator _animator;


    private void Awake()
    {
        //_animator = GetComponent<Animator>();
    }

    public void SubscribeEvent(PlayerModel model)
    {
        model.OnAttack += AttackAnimation;
        model.OnWalk += WalkAnimation;
        model.OnIdle += AttackAnimation;
    }

    void WalkAnimation()
    {
      // _animator.Play("Run");
    }

    void AttackAnimation()
    {
    // _animator.Play("Shoot");   
    }

    void IdleAnimation()
    {
     //_animator.Play("Idle");   
    }
}
