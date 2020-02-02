using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_side_switch : MonoBehaviour
{
    public GameObject switch_moveable;
    public GameObject zoom_object;
    public GameObject[] other_switches;
    public GameObject holo_room_box;
    private Animator switch_animator;
    public GameObject plane_obj;
    public GameObject title;
    // Start is called before the first frame update
    void Start()
    {

    }


    IEnumerator FadeTo(GameObject gameObject, float aValue, float aTime)
    {
        float alpha = gameObject.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            gameObject.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }
    private void OnMouseDown()
    {

        switch_animator = switch_moveable.GetComponent<Animator>();
        if (switch_animator.GetBool("is_pressed") == false)
        {
            switch_animator.SetBool("is_pressed", true);

            //disable all other switches
            foreach (var item in other_switches)
            {
                item.GetComponent<Collider>().enabled = false;
                item.GetComponentInParent<Animator>().SetBool("is_pressed", true);
            }

            StartCoroutine(FadeTo(plane_obj,0.0f, 1.0f));

            zoom_object.GetComponent<Animation>().Play();

            holo_room_box.SetActive(true);

            title.SetActive(false);


            //start routine
            //fade sprite out
            //zoom out switches
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
