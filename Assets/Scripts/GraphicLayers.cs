using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GraphicLayers : MonoBehaviour
{
    public bool isStatic = false;
    private SpriteRenderer _sr;
    public Transform groundPoint;

    public Transform handObject;
    public bool isBehind = false;

    private int _layerNumber;

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
        if(handObject != null )
        {
            HandObjectHandler();
        }
    }

    private void PlaceInLayers()
    {
        _layerNumber = -Mathf.FloorToInt(groundPoint.position.y * 100.0f);
        _sr.sortingOrder = _layerNumber;
    }
    private void HandObjectHandler()
    {
        if(handObject.childCount > 0)
        {
            if(isBehind)
            {
                handObject.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = _layerNumber - 1;
            }
            else
            {
                handObject.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = _layerNumber + 1;
            }
        }
    }
}
