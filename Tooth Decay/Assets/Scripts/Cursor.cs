using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    public float timeOut = 15.0f;
    public Sprite toothBrush;
    public Sprite drill;
    public Sprite hand;
    static public bool inMenu;

    public enum CursorState
    {
        TOOTH_BRUSH = 0,
        DRILL,
        NONE
    };

    static public CursorState state;

    private SpriteRenderer spriteRenderer;
    private int lastButtonPressed;
    private float timerAccumulator;

    // Use this for initialization
    private void Start()
    {
        state = CursorState.NONE;

        spriteRenderer = GetComponent<SpriteRenderer>();

        // State == none
        lastButtonPressed = -1;
        timerAccumulator = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        if (lastButtonPressed == 0 || lastButtonPressed == 1)
        {
            timerAccumulator += Time.deltaTime;

            if (timerAccumulator >= timeOut)
            {
                lastButtonPressed = -1;
                timerAccumulator = 0.0f;
            }
        }

        if (Input.GetMouseButton(0))
        {
            lastButtonPressed = 0;
        }

        if (Input.GetMouseButton(1))
        {
            lastButtonPressed = 1;
        }

        updateCursor();
    }

    private void updateCursor()
    {
        // Only use the hand sprite when the menu is active
        if (inMenu)
        {
            state = CursorState.NONE;
            spriteRenderer.sprite = hand;
            return;
        }

        if (lastButtonPressed == -1)
        {
            state = CursorState.NONE;
            spriteRenderer.sprite = hand;
        }

        if (lastButtonPressed == 0)
        {
            state = CursorState.DRILL;
            spriteRenderer.sprite = drill;
        }

        if (lastButtonPressed == 1)
        {
            state = CursorState.TOOTH_BRUSH;
            spriteRenderer.sprite = toothBrush;
        }
    }

}
