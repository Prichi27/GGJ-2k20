using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pan_zoom : MonoBehaviour
{
    public GameObject main_camera;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDown()
    {
        anim = main_camera.GetComponent<Animation>();
        Debug.Log(anim.name);
        anim.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
