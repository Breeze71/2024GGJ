

namespace V
{
    public interface IDamagable
    {
        public int maxHealth {get; set;}
        // public HealthSystem HealthSystem {get; set;}
        
        public void TakeDamage(int _damageAmount);
        public void Die();
    }
}
