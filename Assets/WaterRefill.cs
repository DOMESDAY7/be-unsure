using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRefill : MonoBehaviour
{
    private WaterParticleController waterReservoir;
    public float refillRate = 20.0f; // Rate at which the reservoir refills per second
    public GameObject seaPlane; // Reference to the sea plane
    public GameObject targetObject; // Reference to the object to check

    void Start()
    {
        waterReservoir = GetComponent<WaterParticleController>();
        if (waterReservoir == null)
        {
            Debug.LogError("No WaterParticleController component found on this GameObject.");
        }

        if (seaPlane == null)
        {
            Debug.LogError("Sea plane not assigned.");
        }

        if (targetObject == null)
        {
            Debug.LogError("Target object not assigned.");
        }
    }

    private void Update()
    {
        if (seaPlane != null && targetObject != null)
        {
            float seaLevel = seaPlane.transform.position.y;
            float targetY = targetObject.transform.position.y;

            if (targetY < seaLevel)
            {
                Debug.Log("R : "+ waterReservoir.waterReservoir);
                if (waterReservoir != null)
                {
                    // Refill the water reservoir
                    waterReservoir.waterReservoir += refillRate * Time.deltaTime;
                    if (waterReservoir.waterReservoir > 100.0f)
                    {
                        waterReservoir.waterReservoir = 100.0f;
                    }

                    // Update the water reservoir bar
                    waterReservoir.UpdateWaterReservoirBar();
                }

                if(targetY < seaLevel - 5)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
