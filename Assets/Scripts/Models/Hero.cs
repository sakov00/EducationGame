using UnityEngine;

namespace Assets.Scripts.Models
{
    public class Hero : MonoBehaviour
    {
        public int Score { get; set; }

        public void ShowScore()
        {
            Debug.Log(Score);
        }
    }
}
