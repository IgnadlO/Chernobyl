using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla : MonoBehaviour
{
    public bool estado;
    public GameObject light;
    

    void Start()
    {
        estado = false;
        light.SetActive(false);
    }
    public void OnTriggerStay(Collider player)
    {
       if(Input.GetButtonDown("Boton0"))
        {
            Estado();
        }
    }

    public void Estado()
    {
        estado = !estado;
        if (estado == true)
            light.SetActive(true);
        else
            light.SetActive(false);


    }
}
