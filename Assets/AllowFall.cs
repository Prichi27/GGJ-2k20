using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowFall : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
