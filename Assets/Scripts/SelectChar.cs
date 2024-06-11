using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SelectChar : MonoBehaviour {
    
    public GameObject basePlane;
    public Transform[] charsPrefabs;
    public Button PreviousBtn;
    public Button NextBtn;
    
    private GameObject currentPlane;
    private int currentChar = 0;
    
    void Start() {
        // Instanciate the first character at the basePlane's position and rotation
        currentPlane = Instantiate(charsPrefabs[currentChar].gameObject, basePlane.transform.position, basePlane.transform.rotation);
        
        // Add button listeners
        PreviousBtn.onClick.AddListener(OnPreviousButtonClick);
        NextBtn.onClick.AddListener(OnNextButtonClick);
    }
    
    void OnPreviousButtonClick() {
        ChangePlane(-1);
    }
    
    void OnNextButtonClick() {
        ChangePlane(1);
    }
    
    void ChangePlane(int direction) {
        Destroy(currentPlane); // Destroy the current plane
        
        currentChar += direction;
        if (currentChar < 0) {
            currentChar = charsPrefabs.Length - 1; // Wrap around to the last character
        } else if (currentChar >= charsPrefabs.Length) {
            currentChar = 0; // Wrap around to the first character
        }
        
        // Instantiate the new character at the basePlane's position and rotation
        currentPlane = Instantiate(charsPrefabs[currentChar].gameObject, basePlane.transform.position, basePlane.transform.rotation);
    }
}
