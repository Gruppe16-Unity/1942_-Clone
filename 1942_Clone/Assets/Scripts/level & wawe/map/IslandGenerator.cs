using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    public GameObject[] islandPrefabs; // Array of island prefabs to choose from
    public float spawnInterval = 2f; // Interval between island spawns
    public float scrollSpeed = 1f; // Speed at which islands scroll down
    public float spawnSpread = 4f; // Maximum spread range for island spawns

    private List<GameObject> spawnedIslands = new List<GameObject>(); // List to keep track of spawned islands
    private SpriteRenderer backgroundRenderer; // Reference to the background sprite renderer
    private Camera mainCamera; // Reference to the main camera

    private void Start()
    {
        backgroundRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;

        // Set the background color to match the tile-set's blue color
        if (backgroundRenderer != null && islandPrefabs.Length > 0)
        {
            Sprite sprite = islandPrefabs[0].GetComponent<SpriteRenderer>().sprite;
            if (sprite != null)
            {
                backgroundRenderer.color = sprite.texture.GetPixel(0, 0);
            }
        }

        // Start spawning islands
        StartCoroutine(SpawnIslands());
    }

    private IEnumerator SpawnIslands()
    {
        while (true)
        {
            // Choose a random island prefab from the array
            GameObject islandPrefab = islandPrefabs[Random.Range(0, islandPrefabs.Length)];

            // Calculate a random spawn position outside the camera view
            Vector3 spawnPosition = GetRandomSpawnPosition();

            // Instantiate the island prefab at the random spawn position
            GameObject island = Instantiate(islandPrefab, spawnPosition, Quaternion.identity);

            // Animate the island by moving it down the screen
            StartCoroutine(AnimateIsland(island));

            // Add the island to the list of spawned islands
            spawnedIslands.Add(island);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float spawnX = Random.Range(-spawnSpread, spawnSpread);
        float spawnY = mainCamera.transform.position.y + (cameraHeight / 2f) + (spawnSpread / 2f);
        return new Vector3(spawnX, spawnY, transform.position.z);
    }

    private IEnumerator AnimateIsland(GameObject island)
    {
        while (island != null)
        {
            // Move the island downwards based on the scroll speed
            island.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

            yield return null;
        }
    }
}
