using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandaid : MonoBehaviour
{

    public Texture2D bandaidSpriteSheet;
    public AudioClip polishBrush;

    private Sprite[] sprites;
    private float timerAccumulator;
    private int swipesPerSecondThreshold;
    private int swipesInTotal;
    private bool enteredArea;
    private AudioSource audioSource;

    // Use this for initialization
    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>(bandaidSpriteSheet.name);

        // Pick a random sprite
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

        // Add a proper collider
        gameObject.AddComponent<PolygonCollider2D>();

        swipesPerSecondThreshold = Random.Range(2, 7);

        timerAccumulator = 0.0f;
        swipesInTotal = 0;
        enteredArea = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        timerAccumulator += Time.deltaTime;

        if (timerAccumulator >= 1.0f)
        {
            swipesInTotal = 0;
            timerAccumulator = 0.0f;
        }
    }

    private void OnMouseExit()
    {
        if (Cursor.state != Cursor.CursorState.TOOTH_BRUSH) { return; }

        ++swipesInTotal;

        if (swipesInTotal >= swipesPerSecondThreshold)
        {
            // Remove the hole + bandaid
            --DamageSpawner.holesLeftToPolish;
            Destroy(transform.parent.gameObject);
        }

        audioSource.PlayOneShot(polishBrush);
    }

}
