using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRefill : MonoBehaviour
{
    private WaterParticleController waterReservoir;
    public float refillRate = 20.0f; // Rate at which the reservoir refills per second

    void Start()
    {
        waterReservoir = GetComponent<WaterParticleController>();
        if (waterReservoir == null)
        {
            Debug.LogError("No WaterParticleController component found on this GameObject.");
        }
    }

    private void Update()
    {
        float y = transform.position.y;
        if(transform.position.y < 9)
        {
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
        }
    }
}
