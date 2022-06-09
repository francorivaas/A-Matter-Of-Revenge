public interface iInput
{    
    float GetH { get; }
    float GetV { get; }
    bool IsMoving();
    public bool IsShooting();
    void UpdateInputs();
}