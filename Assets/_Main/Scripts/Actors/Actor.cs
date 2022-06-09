using System;
using UnityEngine;


public class Actor : MonoBehaviour, iDamageable, iMobile
{
    public float CurrentLife { get; }
    public float MaxLife { get; }

    #region iDamageable

    public virtual void TakeDamage(float x)
    {
       
    }

    public virtual void Die()
    {
       
    }
    public virtual void Idle()
    {
        
    }

    #endregion

    #region iMobile

    public virtual void Walk(Vector3 dir)
    {
       
    }

    public virtual void Attack(float dmg)
    {
        
    }

    public virtual void LookDir(Vector3 dir)
    {
       
    }

    public virtual void Run(Vector3 dir)
    {
       
    }

    public virtual void Move(Vector3 dir, float speed)
    {
        
    }

    public virtual void Chase()
    {
        
    }
    public virtual void Patrol()
    {
        
    }
    #endregion
    
}