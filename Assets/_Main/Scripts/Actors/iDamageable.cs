public interface iDamageable // Can get damage and has a life
{
    float CurrentLife { get; }
    float MaxLife { get; }
    void TakeDamage(float x);
    void Die();
}