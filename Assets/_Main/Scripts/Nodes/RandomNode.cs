using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RandomNode
{
    Roullete<INode> _roulette = new Roullete<INode>();
    Dictionary<INode, int> _items;
    public RandomNode(Dictionary<INode, int> items)
    {
        _items = items;
    }
    public void Execute()
    {
        _roulette.Run(_items).Execute();
    }

}
