using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public interface IVel
{
    float GetVel { get; }
    Vector3 GetFoward { get; }

    Transform GetTarget { get; }
}

