using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollowing : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = 0;

        Vector3 relative = transform.InverseTransformPoint(mouseWorldPosition);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;

        angle = Mathf.Lerp(0, angle, Time.deltaTime * 15.0f);

        transform.Rotate(0, 0, -angle);
    }

}
