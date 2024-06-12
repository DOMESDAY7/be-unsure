using UnityEngine;

public class FireController : MonoBehaviour
{
    private GameObject fireChild;

    void Start()
    {
        // Recherchez un enfant nomm� "fire" dans ce GameObject
        fireChild = transform.Find("Fire")?.gameObject;
        if (fireChild == null)
        {
            Debug.LogError("No child named 'fire' found.");
        }
    }
}
