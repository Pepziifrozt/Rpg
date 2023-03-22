using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    private Camera _cam;
    private Transform _playerTransform;

    [SerializeField] private Vector2 _leftRightBounds = new Vector2(-5.0f, 5.0f);
    [SerializeField] private Vector2 _downUpBounds = new Vector2(-5.0f, 5.0f);

    private Vector3 camMovement;

    private Vector3 _startLocation = new Vector3();

    public void ResetCamera()
    {
        transform.position = _startLocation;
    }

    void Start()
    {
        _cam = GetComponent<Camera>();
        _startLocation = transform.position;
    }
    void LateUpdate()
    {
        FindPlayer();
        if (_playerTransform != null)
        {
            FollowPlayer();
        }
    }
    private void FindPlayer()
    {
        if (_playerTransform == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Debug.LogError("There is no object tagged with 'Player'");
        }

    }
    private void FollowPlayer()
    {
        Vector3 targetPosition = _playerTransform.position + _playerTransform.GetComponent<Movements>().CurrentMove();


        /*if(_playerTransform.GetComponent<Rigidbody2D>()!= null)
        { 
            targetPosition.x += _playerTransform.GetComponent<Rigidbody2D>().velocity.x * _velMultX;  // = does not mean equal
            targetPosition.y += _playerTransform.GetComponent<Rigidbody2D>().velocity.y * _velMultY;  // var += 5 -> var = var + 5;
        }*/
        targetPosition.x = Mathf.Clamp(targetPosition.x, _leftRightBounds.x, _leftRightBounds.y);
        targetPosition.y = Mathf.Clamp(targetPosition.y, _downUpBounds.x, _downUpBounds.y);
        targetPosition.z = transform.position.z;

        //movementVector = Vector3.ClampMagnitude(movementVector, cameraSpeed);

        camMovement = (targetPosition - transform.position);
        camMovement = Vector3.ClampMagnitude(camMovement, cameraSpeed);

        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        transform.Translate(camMovement * Time.deltaTime);
    }
    public void SetUpCamera(float zDistance, float cameraSize, float velocityMultX, float velocityMultY)
    {
        Vector3 pos = _cam.transform.position;
        pos.z = zDistance;
        _cam.transform.position = pos;
        _cam.orthographicSize = cameraSize;
    }
}
