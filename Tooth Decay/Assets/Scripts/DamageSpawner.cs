using System.Collections.Generic;
using UnityEngine;

public class DamageSpawner : MonoBehaviour
{

    public Texture2D spriteSheet;
    public Transform spawnLocations;
    public GameObject holePrefab;

    private Sprite[] sprites;
    private List<Transform> emptySpawnPositions;
    private List<Transform> occupiedSpawnPositions;
    private int totalHolePositions;

    // Use this for initialization
    private void Start()
    {
        // Load every sprite from the sprite sheet
        sprites = Resources.LoadAll<Sprite>(spriteSheet.name);

        emptySpawnPositions = new List<Transform>();
        occupiedSpawnPositions = new List<Transform>();

        loadSpawnLocations();
    }

    private void loadSpawnLocations()
    {
        foreach (Transform child in spawnLocations)
        {
            // Transforms are not occupied by default
            emptySpawnPositions.Add(child);

            ++totalHolePositions;
        }
    }

    private void spawnSingleDamageSprite()
    {
        if (emptySpawnPositions.Count == 0) { return; }

        // Pick a random empty transform from the list
        int randomPositionIndex = Random.Range(0, emptySpawnPositions.Count - 1);
        Transform transform = emptySpawnPositions[randomPositionIndex];

        // Indicate that the transform is now occupied
        occupiedSpawnPositions.Add(transform);

        // Remove the occupied transform from the empty transform list
        emptySpawnPositions.RemoveAt(randomPositionIndex);

        GameObject newSprite = Instantiate(holePrefab, transform.position, new Quaternion(Quaternion.identity.x, Quaternion.identity.y, Random.rotation.z, Quaternion.identity.w));

        // Assign a random hole
        newSprite.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }

    public void spawnDamage()
    {
        // Random number of "holes" to be added to the tooth
        // To keep things fun, not every transform can have a hole assigned to it
        // Otherwise the tooth will look bad in-game
        int holeCount = Random.Range(1, totalHolePositions - 3);

        for (int i = 0; i < holeCount; ++i)
        {
            spawnSingleDamageSprite();
        }
    }

}
