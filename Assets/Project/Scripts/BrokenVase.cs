using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenVase : MonoBehaviour
{
    public GameObject brokenVase;
    public GameObject bulb;
    public Animator shelfDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "VaseIntact")
        {
            Instantiate(brokenVase, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            shelfDoor.SetTrigger("open");

            // Instantiate bulb
            bulb.SetActive(true);
        }
    }
}
