using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public GameObject[] spawnGameObjects;
    private CursorManager _cursorManager;

    private void Awake()
    {
        _cursorManager = GameObject.FindObjectOfType<CursorManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;
        if (other.gameObject.CompareTag("Untagged") || tag != gameObject.name) return;
        Debug.Log(tag);
        var gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (var item in gameObjects)
        {
            item.SetActive(false);
        }

        foreach (var item in spawnGameObjects)
        {
            item.SetActive(true);
        }

        _cursorManager.IsDragging = false;
        _cursorManager.SwitchCursor(0);

    }

}
