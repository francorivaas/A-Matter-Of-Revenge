using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class QuestionNode : INode
{
    Func<bool> _onExecute;
    private INode _trueNode;
    private INode _falseNode;
    public QuestionNode(Func<bool> question, INode trueNode, INode falseNode)
    {
        _onExecute = question;
        _trueNode = trueNode;
        _falseNode = falseNode;
    }
    public void Execute()
    {
        if (_onExecute())
        {
            _trueNode.Execute();
        }
        else
        {
            _falseNode.Execute();
        }
    }
}
