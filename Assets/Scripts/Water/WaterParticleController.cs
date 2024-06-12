using UnityEngine;
using UnityEngine.UI;

public class WaterParticleController : MonoBehaviour
{
    private ParticleSystem waterParticleSystem;
    public float waterReservoir = 100.0f; // 100% full reservoir
    public float depletionRate = 10.0f; // Rate at which the reservoir depletes per second
    public Image waterReservoirBar; // UI Image to display water reservoir level

    private bool consome = false;

    void Start()
    {
        // Get the ParticleSystem component attached to this GameObject
        waterParticleSystem = GetComponent<ParticleSystem>();

        if (waterParticleSystem == null)
        {
            Debug.LogError("No ParticleSystem found on this GameObject.");
        }
    }

    void Update()
    {
            if (Input.GetKey(KeyCode.J) && waterReservoir > 1)
            {
            waterParticleSystem.enableEmission = true;
            consome = true;
            }
            if(!Input.GetKey(KeyCode.J))
            {
                waterParticleSystem.enableEmission = false;
                consome = false;
            }

            if (consome)
            {
                Debug.Log("ça se vide");
                waterReservoir -= depletionRate * Time.deltaTime;
                if (waterReservoir < 0)
                {
                    waterReservoir = 0;
                waterParticleSystem.enableEmission = false;
                }
                waterReservoirBar.fillAmount = waterReservoir / 100;
            }
    }

    public void UpdateWaterReservoirBar()
    {
        if (waterReservoirBar != null)
        {
            waterReservoirBar.fillAmount = Mathf.Clamp(waterReservoir, 0, 100) / 100;
        }
    }
}