using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class ActionNode : INode
{
    Action _action;
    public ActionNode(Action actionToDo)
    {
        _action = actionToDo;
    }
    public void Execute()
    {
        _action?.Invoke();
    }
}
