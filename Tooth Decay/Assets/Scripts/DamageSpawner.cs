using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSpawner : MonoBehaviour
{

    public Texture2D holeSpriteSheet;
    public Transform spawnLocations;
    public GameObject holePrefab;
    public MouthChanger mouth;
    static public int holesLeftToPolish;

    private Sprite[] sprites;
    private List<Transform> emptySpawnPositions;
    private List<Transform> occupiedSpawnPositions;
    private int totalHolePositions;

    // Use this for initialization
    private void Start()
    {
        // Load every sprite from the sprite sheet
        sprites = Resources.LoadAll<Sprite>(holeSpriteSheet.name);

        emptySpawnPositions = new List<Transform>();
        occupiedSpawnPositions = new List<Transform>();

        loadSpawnLocations();
    }

    private void Update()
    {
        float percentage = ((float)holesLeftToPolish / (float)occupiedSpawnPositions.Count) * 100.0f;

        if (percentage >= 75.0f)
        {
            mouth.UpdateMouthSprite(MouthChanger.MouthTypes.SAD);
        }
        else if (percentage >= 50.0f)
        {
            mouth.UpdateMouthSprite(MouthChanger.MouthTypes.NO_EMOTION);
        }
        else if (percentage >= 25.0f)
        {
            mouth.UpdateMouthSprite(MouthChanger.MouthTypes.HAPPY);
        }
        else
        {
            mouth.UpdateMouthSprite(MouthChanger.MouthTypes.AMAZED);
        }
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
        int randomPositionIndex = Random.Range(0, emptySpawnPositions.Count);
        Transform transform = emptySpawnPositions[randomPositionIndex];

        // Indicate that the transform is now occupied
        occupiedSpawnPositions.Add(transform);

        // Remove the occupied transform from the empty transform list
        emptySpawnPositions.RemoveAt(randomPositionIndex);

        GameObject newHole = Instantiate(holePrefab, transform.position, new Quaternion(Quaternion.identity.x, Quaternion.identity.y, Random.rotation.z, Quaternion.identity.w));

        // Assign a random hole
        newHole.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    public void spawnDamage()
    {
        // Random number of "holes" to be added to the tooth
        // To keep things fun, not every transform can have a hole assigned to it
        // Otherwise the tooth will look bad in-game
        int holeCount = Random.Range(1, totalHolePositions - 4);

        for (int i = 0; i < holeCount; ++i)
        {
            spawnSingleDamageSprite();
        }
    }

}
