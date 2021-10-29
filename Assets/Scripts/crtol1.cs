using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crtol1 : MonoBehaviour
{
    private Animator ani;
    public int vidas=5;
    public Text txtMsj;
    public Text txtVidas;

    void Start () {
        ani = GetComponent<Animator> ();
        txtVidas.text = "Vidas : " + vidas;
    }
        
    void Update () {
        float v,r;
        v = Input.GetAxis ("Vertical"); 
        r = Input.GetAxis ("Horizontal"); 

        transform.Rotate(0,r,0);
        ani.SetFloat("velocidad",v);

        if(vidas <= 0)
        {
            txtMsj.text = "Se te acabaron las vidas";
            GetComponent<crtol1>().enabled = false;
            ani.SetBool("isMorido", true);
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.gameObject.tag == "Enemy")
        {
            if(vidas > 0)
            {
                vidas--;
                txtVidas.text = "Vidas : " + vidas;
            }
        }
    }

}
