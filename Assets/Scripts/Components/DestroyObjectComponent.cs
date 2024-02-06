using UnityEngine;

namespace Assets.Scripts.Components
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        public void DestroyObject(GameObject targetObject)
        {
            if (targetObject != null)
            {
                Destroy(targetObject);
            }
        }
    }
}
