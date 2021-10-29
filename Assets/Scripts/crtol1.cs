using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crtol1 : MonoBehaviour
{
    private Animator ani;

    void Start () {
        ani = GetComponent<Animator> ();
    }
        
    void Update () {
        float v,r;
        v = Input.GetAxis ("Vertical"); 
        r = Input.GetAxis ("Horizontal"); 

        transform.Rotate(0,r,0);
        ani.SetFloat("velocidad",v);
    }

}
