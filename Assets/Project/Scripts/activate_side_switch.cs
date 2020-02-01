using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_side_switch : MonoBehaviour
{
    public GameObject switch_moveable;
    private Animator switch_animator;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDown()
    {

        switch_animator = switch_moveable.GetComponent<Animator>();
        if (switch_animator.GetBool("is_pressed") == false)
        {
            switch_animator.SetBool("is_pressed", true);
        }
        else {      
            switch_animator.SetBool("is_pressed", false);
        };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
