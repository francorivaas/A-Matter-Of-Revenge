using System;

public class PlayerIdleState<T> : State<T>
{
    T _inputWalk;
    T _inputShoot;
    private Action _onIdle;
    private iInput _playerInput;

    public PlayerIdleState(Action onIdle, T inputWalk, T inputShoot, iInput playerInput)
    {
        _inputWalk = inputWalk;
        _inputShoot = inputShoot;
        _onIdle = onIdle;
        _playerInput = playerInput;
    }


    public override void Execute()
    {
        _playerInput.UpdateInputs();
        if (_playerInput.IsMoving())
        {
            _parentFSM.Transition(_inputWalk);
            return;
        }

        if (_playerInput.IsShooting())
        {
            _parentFSM.Transition(_inputShoot);
        }
        _onIdle?.Invoke();
    }
}
