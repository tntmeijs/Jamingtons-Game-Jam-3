using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public AudioClip drillSound;
    public GameObject bandaidPrefab;
    public int scoreValue = 10;
    
    private bool hasBandaid;
    private int clickPerSecondThreshold;
    private int clicksInTotal;
    private float timerAccumulator;
    private AudioSource audioSource;

    // Use this for initialization
    private void Start()
    {
        hasBandaid = false;

        // Add a proper collider
        gameObject.AddComponent<PolygonCollider2D>();

        // Random number of mouse clicks per second
        clickPerSecondThreshold = Random.Range(1, 6);
        float randomScale = Random.Range(0.6f, 1.0f);
        transform.localScale = new Vector2(randomScale, randomScale);
        transform.rotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, Random.rotation.eulerAngles.z, Quaternion.identity.w);

        clicksInTotal = 0;
        timerAccumulator = 0.0f;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        timerAccumulator += Time.deltaTime;

        if (timerAccumulator >= 1.0f)
        {
            clicksInTotal = 0;
            timerAccumulator = 0.0f;
        }
    }

    private void OnMouseDown()
    {
        // TODO: use true clicks per second calculation
        if (hasBandaid && Cursor.state != Cursor.CursorState.DRILL) { return; }
        
        ++clicksInTotal;

        audioSource.PlayOneShot(drillSound);

        if (clicksInTotal >= clickPerSecondThreshold)
        {
            GameManager.score += scoreValue;
            Instantiate(bandaidPrefab, transform);
            hasBandaid = true;
        }
    }

}
