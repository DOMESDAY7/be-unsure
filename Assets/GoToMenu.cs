using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to load the menu after 3 seconds
        StartCoroutine(LoadMenuAfterDelay(3f));
    }

    // Coroutine to handle the delay
    IEnumerator LoadMenuAfterDelay(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Load the menu scene
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
