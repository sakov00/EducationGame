using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.PlayerComponents
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private UnityEvent onDamage;
        [SerializeField] private UnityEvent OnDie;

        public void ApplyDamage(int damageValue)
        {
            health -= damageValue;
            onDamage?.Invoke();
            if (health <= 0)
            {
                OnDie?.Invoke();
            }
        }
    }
}