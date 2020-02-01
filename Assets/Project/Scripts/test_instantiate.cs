using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_instantiate : MonoBehaviour
{
    public GameObject vase_prefab;
    public GameObject broken_vase_prefab;
    public GameObject cube;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space");
            Instantiate(vase_prefab, cube.transform.position, cube.transform.rotation);
        }
        else if (Input.GetKeyDown("a")) {
            Instantiate(broken_vase_prefab, cube.transform.position, cube.transform.rotation);
        };

    }
}
