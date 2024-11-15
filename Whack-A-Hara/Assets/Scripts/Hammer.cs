using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        HitMole();
    }
    void FollowMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        transform.position = mouse;
        
    }
    void HitMole()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("HitMole");
        }
    }
}
