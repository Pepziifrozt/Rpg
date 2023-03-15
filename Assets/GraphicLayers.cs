using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GraphicLayers : MonoBehaviour
{
    public bool isStatic = false;
    private SpriteRenderer _sr;
    public Transform groundPoint;

    void Start()
    {
        if(GetComponent<SpriteRenderer>() != null)
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        if (isStatic)
        {
            PlaceInLayers();
            Destroy(this);
        }
    }

    private void Update()
    {
        PlaceInLayers();
    }

    private void PlaceInLayers()
    {
        _sr.sortingOrder = -Mathf.FloorToInt(groundPoint.position.y * 100.0f);
    }
}
