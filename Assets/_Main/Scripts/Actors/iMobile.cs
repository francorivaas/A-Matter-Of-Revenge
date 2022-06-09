// All actors that have movement use this interface

using UnityEngine;

public interface iMobile // Can move and attack
{
    void Idle();
    void Walk(Vector3 dir);
    
    void Attack(float dmg);

    void Patrol();

    void Chase();

    void Move(Vector3 dir, float speed);
        
    void Run(Vector3 dir);
}