using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pan_zoom : MonoBehaviour
{
    public GameObject main_camera;
    public GameObject switch_moveable;
    public GameObject holo_switch;
    public GameObject holo_room_box;
    public GameObject plane_obj;

    private Animator switch_animator;
    private Animation camera_anim;

    private bool hasPlayedIntro;
    private int switch_counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch_animator = switch_moveable.GetComponent<Animator>();
        camera_anim = main_camera.GetComponent<Animation>();

    }

    IEnumerator blink_switch_off()
    {
        
        //display the title and reset the switch to initial
        //display hologram temporarily on button
        switch_animator.SetBool("is_pressed", true);
        holo_switch.SetActive(true);
        yield return new WaitForSeconds(0.50f);
        switch_animator.SetBool("is_pressed", false);
        holo_switch.SetActive(false);
        switch_counter++;
    }

    IEnumerator blink_switch_on(){
        //zoom out and display all 4 switches
        //make the switch unclickable and full of hologram
        //once we click on any of the other switches make all switches disappear and make the lights
        //gradually increase in lighting
        camera_anim = main_camera.GetComponent<Animation>();
        camera_anim.Play();
        hasPlayedIntro = true;
        switch_animator.SetBool("is_pressed", true);
        yield return new WaitForSeconds(0.50f);
        switch_animator.SetBool("is_pressed", false);
        holo_switch.SetActive(true);
        holo_room_box.SetActive(true);
        switch_counter++;
    }
    private void OnMouseDown()
    {
        
        switch (switch_counter)
        {
            case 0:
                StartCoroutine(blink_switch_off());
                break;
            case 1:
                StartCoroutine(blink_switch_on());
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
