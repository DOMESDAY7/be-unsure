using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlacer : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private int numberOfTrees = 100;
    [SerializeField] private float heightThreshold = 62.0f; // Height threshold for placing trees
    [SerializeField] private int stepSize = 5; // Step size for sampling points on the terrain

    private Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        PlaceTrees();
    }

    void PlaceTrees()
    {
        if (treePrefab == null)
        {
            Debug.LogError("Tree prefab is not assigned.");
            return;
        }

        List<Vector3> validPoints = GetValidPoints();

        for (int i = 0; i < numberOfTrees; i++)
        {
            if (validPoints.Count == 0)
                break;

            int index = Random.Range(0, validPoints.Count);
            Vector3 treePosition = validPoints[index];
            Instantiate(treePrefab, treePosition, Quaternion.identity);

            validPoints.RemoveAt(index); // Remove the used point to avoid placing multiple trees in the same spot
        }
    }

    List<Vector3> GetValidPoints()
    {
        List<Vector3> validPoints = new List<Vector3>();

        // Get the terrain size
        int terrainWidth = (int)terrain.terrainData.size.x;
        int terrainHeight = (int)terrain.terrainData.size.z;

        // Iterate over the terrain positions to find valid points
        for (int x = 0; x < terrainWidth; x += stepSize)
        {
            for (int z = 0; z < terrainHeight; z += stepSize)
            {
                float y = terrain.SampleHeight(new Vector3(x, 0, z));
                if (y > heightThreshold) // Check if the position is above the height threshold
                {
                    Vector3 position = new Vector3(x, y, z);
                    validPoints.Add(position);
                }
            }
        }

        return validPoints;
    }
}
