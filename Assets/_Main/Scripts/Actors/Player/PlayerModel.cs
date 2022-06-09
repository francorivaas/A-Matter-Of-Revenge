using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerModel : Actor
{
    #region Properties
    private Rigidbody _rb;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private PlayerView _animation;
    //[SerializeField] private Weapon _weapon;
   //[SerializeField] private float shotCD;
    private float _nextFire;
    private Camera _camera;

    #region Actions

    public event Action OnAttack;
    public event Action OnWalk;
    public event Action OnIdle;

    #endregion

    private Transform _transform;
    // Damageable properties
    float CurrentLife => life;
    [Header("Current Life")]
    [SerializeField] private float life = 10;
    // public float MaxLife => maxLife;
    // [Header("Maximum Life")]
    [SerializeField] private float maxLife = 10;
    public event Action OnDie;
    private float _currSpeed;
    private Quaternion _currRot;
    #endregion
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animation = GetComponent<PlayerView>();
        _transform = transform;
        _camera = Camera.main;
    }

    private void Start()
    {
        _animation.SubscribeEvent(this);
        _nextFire = 0;
    }

    public void Subscribe(PlayerController controller)
    {
        controller.OnIdle += Idle;
        controller.OnMove += Walk;
        controller.OnMelee += Attack;
    }

    #region Mobile Methods
    public void Walk(Vector3 dir)
    {
        Move(dir, walkSpeed);
        _currSpeed = walkSpeed;

    }

    public override void Idle()
    {
        _rb.velocity = Vector3.zero;
        CorrectRotation();
        OnIdle?.Invoke();
    }

    
    private void CorrectRotation()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            var distance = Vector3.Distance(transform.position, hitInfo.point);
            if (distance >= 2.5f)
                transform.LookAt(target);
        }
    }  
     
    public override void Move(Vector3 dir, float speed)
    {
        var normalizedDir = dir.normalized;
        _rb.velocity = new Vector3(normalizedDir.x*speed,_rb.velocity.y,normalizedDir.z*speed);
        CorrectRotation();
        OnWalk?.Invoke();

    }

    public override void Attack(float dmg)
    {
            OnAttack?.Invoke();
 
    }

    public void Run(Vector3 dir)
    {
        Move(dir,runSpeed);
        _currSpeed = runSpeed;
    }

    #endregion

    #region Damageable Methods
    public override void Die()
    {
        OnDie?.Invoke();
        Destroy(gameObject);
    }

    public override void TakeDamage(float dmg)
    {
        life -= dmg;
        if (CurrentLife <=0)
        {
            Die();
        }
    }
    public bool IsAlive()
    {
        return CurrentLife > 0;
    }

    
    #endregion

    public float Vel => _currSpeed;
}
