using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FSM<T>
{
    private IState<T> _currentState;
    public IState<T> CurrentState => _currentState;
    public FSM(State<T> initalState)
    {
        SetInitialState(initalState);
    }
    public void SetInitialState(State<T> stateToSet)
    {
        _currentState = stateToSet;
        _currentState.Awake();
        _currentState._parentFSM = this;
    }
    public void Transition(T input)
    {
        IState<T> stateToTransit = _currentState.GetTransition(input);
        if (stateToTransit == null) 
        { 
            return; 
        } 
        else
        {
            _currentState.Sleep();
            _currentState = stateToTransit;
            _currentState._parentFSM = this;
            _currentState.Awake();
        }
    }
    public void UpdateState()
    {
        if(_currentState != null)
        _currentState.Execute();
    }
}
