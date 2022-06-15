
using UnityEngine;

public class PlayerInput : MonoBehaviour, iInput
{
    #region Properties
    private float _h;
    private float _v;
    public float GetH => _h;
    public float GetV => _v;
    #endregion

    #region Methods
    
    public bool IsMoving()
    {
        return (GetH != 0 || GetV != 0 );
    }

    public bool IsShooting()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    public void UpdateInputs()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        // _h = Mathf.Clamp(_h,0,1);
        // _v = Mathf.Clamp(_v,0,1);
    }
    #endregion
}
