using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public RectTransform crosshair;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        crosshair.position = mousePosition;
    }
}
