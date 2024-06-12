using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FireCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fireCountText;
    [SerializeField] private float updateInterval = 0.1f; // Update interval in seconds

    private float timer;

    void Start()
    {
        // Initial count at the start
        CountFireParticles();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateInterval)
        {
            CountFireParticles();
            timer = 0f;
        }
    }

    void CountFireParticles()
    {
        int totalFireCount = 0;
        int extinguishedFireCount = 0;
        ParticleSystem[] allParticles = FindObjectsOfType<ParticleSystem>();

        foreach (ParticleSystem ps in allParticles)
        {
            if (ps.CompareTag("Fire")) // Assuming your fire particles have the tag "Fire"
            {
                totalFireCount++;
                if (!ps.isPlaying) // If the particle system is stopped
                {
                    extinguishedFireCount++;
                }
            }
        }

        float percentage = (totalFireCount > 0) ? ((float)extinguishedFireCount / totalFireCount) * 100 : 0;

        string result = $"Feu éteint {percentage:F2}% ({extinguishedFireCount}/{totalFireCount})";

        if(percentage == 1)
        {
            SceneManager.LoadScene("Win");
        }

        if (fireCountText != null)
        {
            fireCountText.text = result;
        }
        else
        {
            Debug.LogError("FireCountText is not assigned in the inspector.");
        }
    }
}
