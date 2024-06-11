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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.CompareTag("Water"))
        {
            Debug.Log("Water detected, extinguishing fire.");
            ExtinguishFire();
        }
    }

    private void ExtinguishFire()
    {
        if (fireChild != null)
        {
            fireChild.SetActive(false);  // D�sactive l'enfant "fire"
            Debug.Log("Fire deactivated.");
        }
        else
        {
            Debug.LogError("Fire child GameObject is not assigned.");
        }
    }
}
