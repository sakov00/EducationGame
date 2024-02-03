using UnityEngine.Events;
using UnityEngine;
using Assets.Scripts.Player.MVC.Models;
using Assets.Scripts.Player.MVC.Views;


namespace Assets.Scripts.Player.MVC.Controllers
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private int health;
        [SerializeField] private UnityEvent onDamage;
        [SerializeField] private UnityEvent OnDie;

        private PlayerModel playerModel;
        private PlayerView playerView;

        private void Awake()
        {
            playerView = GetComponent<PlayerView>();
        }

        public void ApplyDamage(int damageValue)
        {
            health -= damageValue;
            onDamage?.Invoke();
            playerView.SetHittedForAnimation();
            if (health <= 0)
            {
                OnDie?.Invoke();
            }
        }
    }
}
