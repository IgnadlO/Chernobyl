using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaRota : MonoBehaviour
{
    private Animation animacion;

    void Start()
    {
        animacion = GetComponent<Animation>();
    }

    public void OnTriggerStay(Collider player)//sacarlo
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cae();
        }
    }
    public void Cae()
    {
            animacion.Play("CaePuertaRota");
    }
}

