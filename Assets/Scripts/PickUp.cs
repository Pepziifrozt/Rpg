using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PickUp : MonoBehaviour
{
    private bool _isPickedUp = false;
    private bool _playerHere = false;
    
    void Update()
    {
        if(_playerHere && !_isPickedUp)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickUpObject();
            }
        }
        else if (_isPickedUp && Input.GetKeyDown(KeyCode.F)) 
        {
            Drop();
        }
    }
    private void PickUpObject()
    {
        _isPickedUp=true;

        transform.parent = GameObject.FindGameObjectWithTag("HandPoint").transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    private void Drop()
    {
        transform.parent = null;
        transform.rotation = Quaternion.identity;
        _isPickedUp = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player") && !_isPickedUp)
        {
            _playerHere = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isPickedUp)
        {
            _playerHere = true;
        }
    }
}
