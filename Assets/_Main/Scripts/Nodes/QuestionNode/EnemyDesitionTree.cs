using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class EnemyDesitionTree : MonoBehaviour
{
    [SerializeField] bool shootRange;
    [SerializeField] bool inSight;
    [SerializeField] bool ammoCheck;
    [SerializeField] bool enemyCheck;
    private void Awake()
    {
        InitializeTree();
    }
    void InitializeTree()
    {
        INode shoot = new ActionNode(() => print ("Shoot"));
        INode chase = new ActionNode(() => print("Chase"));
        INode reload = new ActionNode(() => print("Recharge"));
        INode patrol = new ActionNode(() => print("Patrol"));

        INode QShootRange = new QuestionNode(ShootRange, shoot, patrol);
        INode Qlos = new QuestionNode(InSight, QShootRange, patrol);
        INode QAmmoCheck = new QuestionNode(AmmoCheck, Qlos, reload);
        INode QEnemyCheck = new QuestionNode(() => enemyCheck, QAmmoCheck, patrol);


        Dictionary<INode, int> itemRandom = new Dictionary<INode, int>();

        itemRandom[shoot] = 25;
        itemRandom[patrol] = 15;
        itemRandom[reload] = 5;
    }
    
    bool AmmoCheck()
    {
        return ammoCheck;
    }
    bool InSight()
    {
        return inSight;
    }
    bool ShootRange()
    {
        return shootRange;
    }

}
