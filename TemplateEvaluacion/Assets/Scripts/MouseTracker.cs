using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private Vector2 mousePosition;

    public Vector2 MousePosition { get { return mousePosition; } }


    void Start()
    {
        mousePosition = new Vector2();
    }


    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
