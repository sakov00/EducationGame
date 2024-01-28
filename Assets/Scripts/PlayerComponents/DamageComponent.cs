using UnityEngine;

namespace Assets.Scripts.PlayerComponents
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] private int damageValue;

        public void DamageObject(GameObject target)
        { 
            var healthComponent = GetComponent<HealthComponent>();
            if (healthComponent != null)
            { 
                healthComponent.ApplyDamage(damageValue);
            }
        }
    }
}
