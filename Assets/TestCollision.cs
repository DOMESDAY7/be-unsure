using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TestCollision: Collision detected with: " + other.gameObject.name);
    }
}
