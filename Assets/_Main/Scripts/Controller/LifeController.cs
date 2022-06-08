using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class LifeController : MonoBehaviour
{
    private float _currentLife;
    [SerializeField]private float _maxLife;
    public Action actionToDo;
    [SerializeField] private bool isInmortal;
    private void Start()
    {
        _currentLife = _maxLife;
    }
    public void TakeDamage(float damage)
    {
        _currentLife -= damage;
    }
    public void CheckCurrentLife()
    {
        if(_currentLife <= 0)
        {
            if (!isInmortal)
            {
                actionToDo?.Invoke();
            }
        }
    }

}
