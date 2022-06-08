using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IState<T>
{
    public void Awake();
    public void Execute();
    public void Sleep();
    public void AddTransition(T input, IState<T> stateToTransit);
    public void RemoveTransition(T input);
    public void RemoveTransition(IState<T> state);
    public IState<T> GetTransition(T input);
    FSM<T> _parentFSM { get; set;}
}
