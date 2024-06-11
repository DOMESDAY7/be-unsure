using MFlight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureManager : MonoBehaviour
{
    public GameObject directionalLight;
    public GameObject rain;
    public KeyCode rainToggleKey = KeyCode.P; // Default key for toggling rain
    public KeyCode lightToggleKey = KeyCode.L; // Default key for toggling light
    public KeyCode rotationToggleKey = KeyCode.R; // Default key for toggling rotation animator
    public KeyCode FPVToggleKey = KeyCode.F; // Default key for toggling FPV

    private Animator directionalLightAnimator; // Animator component for directional light
    private bool isDay = true;
    private bool isAnimatorActive = false;

    private Quaternion dayRotation;
    private Quaternion nightRotation;

    private CloudMaster cloudMaster;
    private MouseFlightController mouseFlightController;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure rain is initially disabled
        if (rain != null)
        {
            rain.SetActive(true);
        }

        // Find the Animator component in the directional light
        if (directionalLight != null)
        {
            directionalLightAnimator = directionalLight.GetComponent<Animator>();
            if (directionalLightAnimator != null)
            {
                directionalLightAnimator.enabled = false; // Ensure animator is initially disabled
            }
        }

        dayRotation = directionalLight.transform.rotation;
        nightRotation = Quaternion.Euler(210, directionalLight.transform.rotation.eulerAngles.y, directionalLight.transform.rotation.eulerAngles.z);

        cloudMaster = FindObjectOfType<CloudMaster>();
        mouseFlightController = FindObjectOfType<MouseFlightController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRainToggle();
        HandleLightToggle();
        HandleRotationToggle();
        HandleFPVToggle();
    }

    void HandleRainToggle()
    {
        if (Input.GetKeyDown(rainToggleKey))
        {
            cloudMaster.ActiveRain = !cloudMaster.ActiveRain;
        }
    }

    void HandleLightToggle()
    {
        if (Input.GetKeyDown(lightToggleKey))
        {
            if (directionalLight != null)
            {
                if (isDay)
                {
                    directionalLight.transform.rotation = dayRotation;
                }
                else
                {
                    directionalLight.transform.rotation = nightRotation;
                }
                isDay = !isDay;
            }
        }
    }

    void HandleRotationToggle()
    {
        if (Input.GetKeyDown(rotationToggleKey))
        {
            if (directionalLightAnimator != null)
            {
                isAnimatorActive = !isAnimatorActive;
                directionalLightAnimator.enabled = isAnimatorActive;
            }
        }
    }

    void HandleFPVToggle()
    {
        if (Input.GetKeyDown(FPVToggleKey))
        {
            if (mouseFlightController != null)
            {
                mouseFlightController.FPV = !mouseFlightController.FPV;
            }
        }
    }
}
