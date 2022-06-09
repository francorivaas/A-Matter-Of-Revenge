using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Properties

    private FSM<PlayerStatesEnum> _fsm;
    private PlayerModel _player;
    private iInput _playerInput;
    #endregion

    public event Action<Vector3> OnMove; 
    public event Action OnIdle;
    public event Action<float> OnMelee;
    public float shotgunDmg;
    private void Awake()
    {
        _player = GetComponent<PlayerModel>();
        _playerInput = GetComponent<iInput>();
        
        FsmInit();
    }

    private void Start()
    {
        _player.Subscribe(this);
    }

    private void FsmInit()
    {
        
        //--------------- FSM Creation -------------------//                
        var idle = new PlayerIdleState<PlayerStatesEnum>(IdleCommmand, PlayerStatesEnum.Walk,PlayerStatesEnum.Melee,_playerInput );
        var walk = new PlayerWalkState<PlayerStatesEnum>(WalkCommmand, PlayerStatesEnum.Idle, PlayerStatesEnum.Melee, _playerInput);
        var shoot = new PlayerAttackState<PlayerStatesEnum>(PlayerStatesEnum.Idle,PlayerStatesEnum.Walk,ShootCommand,shotgunDmg,_playerInput);
        
        
        // Idle
        idle.AddTransition(PlayerStatesEnum.Walk, walk);
        idle.AddTransition(PlayerStatesEnum.Melee, shoot);
        
        // Walk
        walk.AddTransition(PlayerStatesEnum.Idle, idle);
        walk.AddTransition(PlayerStatesEnum.Melee, shoot);
        
        // Melee
        shoot.AddTransition(PlayerStatesEnum.Idle, idle);
        shoot.AddTransition(PlayerStatesEnum.Walk, walk);

        _fsm = new FSM<PlayerStatesEnum>(idle);
        // Set init state
        

    }

    public void WalkCommmand(Vector3 dir)
    {
        OnMove?.Invoke(dir);
    }
    public void IdleCommmand()
    {
        OnIdle?.Invoke();
    }

    public void ShootCommand(float dmg)
    {
        OnMelee?.Invoke(dmg);   
    }
    
    void Update()
    {
        _fsm.UpdateState();   
    }


}

