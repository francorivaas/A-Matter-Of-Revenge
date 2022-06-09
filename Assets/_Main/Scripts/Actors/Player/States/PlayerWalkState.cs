using System;
using UnityEngine;

public class PlayerWalkState<T> : State<T>
{
    private T _inputIdle;
    private T _inputMelee;
    private Action<Vector3> _onWalk;
    private iInput _playerInput;

    public PlayerWalkState(Action<Vector3> onWalk, T inputIdleIdle,T inputMelee, iInput playerInput)
    {
        _onWalk = onWalk;
        _inputMelee = inputMelee;
        _inputIdle = inputIdleIdle;
        _playerInput = playerInput; 
    }

    public override void Execute()
    {
        _playerInput.UpdateInputs();
        var h = _playerInput.GetH;
        var v = _playerInput.GetV;
       
        if (!_playerInput.IsMoving())
        {
            _parentFSM.Transition(_inputIdle);
            return; // Trans to Idle
        }
        if(_playerInput.IsShooting())
        {
            _parentFSM.Transition(_inputMelee);
            return;
        }
        
        Vector3 dir = new Vector3(h, 0, v);
        _onWalk?.Invoke(dir);
        
    }
}
