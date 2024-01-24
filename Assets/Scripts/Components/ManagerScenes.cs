using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Components
{
    public class ManagerScenes : MonoBehaviour
    {
        public void RestartLevel() 
        {
            var activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }
    }
}
