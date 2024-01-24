using UnityEngine;

public class DestroyObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    public void DestroyObject()
    {
        if (targetObject != null)
        {
            Destroy(targetObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}