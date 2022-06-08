using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class State<T>: IState<T>
{
    FSM<T> parentFSM;
    public FSM<T> _parentFSM { get => parentFSM; set => parentFSM = value; }
    protected Dictionary<T, IState<T>> transitions = new Dictionary<T, IState<T>>();
    public virtual void Awake()
    {
    }

    public virtual void Execute()
    {

    }

    public virtual void Sleep()
    {
    }

    public void AddTransition(T input, IState<T> stateToTransit)
    {
        //if (transitions.ContainsKey(input))
        //{
        //    return;
        //}
        //transitions.Add(input, stateToTransit);
        transitions[input] = stateToTransit;
        return;
    }

    public void RemoveTransition(T input)
    {
        if (!transitions.ContainsKey(input))
        {
            return;
        }
        transitions.Remove(input);
    }

    public void RemoveTransition(IState<T> state)
    {
        if (!transitions.ContainsValue(state))
        {
            return;
        }
        else
        {
            foreach (var item in transitions)
            {
                if (item.Value == state)
                {
                    transitions.Remove(item.Key);
                }
            }
        }

    }

    public IState<T> GetTransition(T input)
    {
        if (!transitions.ContainsKey(input))
        {
            return null;
        }
        else
        {
            return transitions[input];
        }
    }
    
    public void SetFSM(FSM<T> fsm)
    {
        _parentFSM = fsm;
    }


}
