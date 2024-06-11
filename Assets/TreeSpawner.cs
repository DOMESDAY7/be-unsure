using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;  // Assignez le prefab de l'arbre dans l'inspecteur
    public int treeCount = 100000;  // Nombre d'arbres à placer
    public Terrain terrain;  // Le terrain sur lequel placer les arbres

    void Start()
    {
        int treesSpawned = 0;
        int attempts = 0;

        while (treesSpawned < treeCount)
        {
            // Générer une position aléatoire dans les limites du terrain
            float x = Random.Range(0, terrain.terrainData.size.x);
            float z = Random.Range(0, terrain.terrainData.size.z);

            // Obtenir la hauteur du terrain à cette position
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrain.GetPosition().y;

            // Vérifier si la hauteur est supérieure à 25
            if (y > 25)
            {
                // Créer la position finale pour l'arbre
                Vector3 position = new Vector3(x, y, z);

                // Instancier l'arbre à cette position
                Instantiate(treePrefab, position, Quaternion.identity);

                treesSpawned++;
            }

            attempts++;
        }

        Debug.Log($"Spawned {treesSpawned} trees after {attempts} attempts.");
    }
}
