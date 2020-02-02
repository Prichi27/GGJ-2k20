using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_cupboard : MonoBehaviour
{
    private float _updatedXAxis;
    private float _initialXAxis;
    private float _maxX = -86f;
    private float _minX = -50f;
    private float _ratio;

    public GameObject shelf;

    // Start is called before the first frame update
    void Start()
    {
        _initialXAxis = GetComponent<Transform>().position.x;

    }

    // Update is called once per frame
    void Update()
    {
        //update z axis value
        _updatedXAxis = GetComponent<Transform>().position.x;

        if (_updatedXAxis > _maxX && _updatedXAxis < _minX)
        {
            _ratio = (_maxX - _updatedXAxis) / (_maxX - _minX);
            shelf.GetComponent<Transform>().rotation = new Quaternion(shelf.GetComponent<Transform>().rotation.x,
                                                                        shelf.GetComponent<Transform>().rotation.y,
                                                                        -(90 * _ratio),
                                                                        1); ;
        } else {

        }



    }
}
