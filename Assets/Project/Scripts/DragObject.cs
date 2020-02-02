using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragObject : MonoBehaviour
{
    private List<Rigidbody> _rbs;

    private GameObject[] _gameObjects;
    private Vector3 _gameObjectScreenPosition;
    private Vector3 _mouseInitialPosition;
    private Vector3 _mouseTargetPosition;
    private Vector3 _force;
    private List<Vector3> _objectInitialPosition;
    private List<Vector3> _objectTargetPosition;

    private bool _isDragging;

    private CursorManager _cursorManager;

    public float forceAmplifier = 10f;
    public float maxSpeed = 10f;
    private bool _carrying;

    private void Awake()
    {
        _rbs = new List<Rigidbody>();
        _cursorManager = GameObject.FindObjectOfType<CursorManager>();
    }
    private void OnMouseDown()
    {
        // Find all object with the same tag
        if (_gameObjects == null)
        {
            _gameObjects = GameObject.FindGameObjectsWithTag(gameObject.tag);
            foreach (GameObject item in _gameObjects)
            {
                _rbs.Add(item.GetComponent<Rigidbody>());
            }
        }

        _carrying = true;
        _cursorManager.IsDragging = true;
        _cursorManager.DragGameObject = gameObject;

        // Prevents Object from falling
        foreach (Rigidbody rigidbody in _rbs)
        {
            rigidbody.useGravity = false;
        }
        _gameObjectScreenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _mouseInitialPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _gameObjectScreenPosition.z);

        if (!_isDragging)
        {
            foreach (Rigidbody rigidbody in _rbs)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
            }
        }

        _isDragging = false;

    }


    private void OnMouseDrag()
    {       
        _mouseTargetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _gameObjectScreenPosition.z);
        _force = (_mouseTargetPosition - _mouseInitialPosition) * forceAmplifier;
        _mouseInitialPosition = _mouseTargetPosition;
        _isDragging = true;
    }
    
    private void OnMouseUp()
    {
        // Reapply gravity after mouse is released
        foreach (Rigidbody rigidbody in _rbs)
        {
            rigidbody.useGravity = true;         
        }

        _force = Vector3.zero;
        _carrying = false;
        _cursorManager.IsDragging = false;
        _cursorManager.SwitchCursor(0);

    }

    private void OnMouseEnter()
    {
        _cursorManager.SwitchCursor(1);
    }

    private void OnMouseExit()
    {
        _cursorManager.SwitchCursor(0);
    }

    private void FixedUpdate()
    {
        if (_force != Vector3.zero )
        {
            foreach (Rigidbody rigidbody in _rbs)
            {
                rigidbody.velocity = _force;
                rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, maxSpeed);
            }


        }

        //if (_cursorManager.IsDragging)
        //_cursorManager.SetTextureLocation(gameObject.transform.position);
    }

    private void Update()
    {
        if(_carrying)
        {
            _cursorManager.SwitchCursor(2);
            _cursorManager.SetTextureLocation(gameObject.transform.position);


        }
    }
}
