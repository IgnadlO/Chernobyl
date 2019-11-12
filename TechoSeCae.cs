using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechoSeCae : MonoBehaviour
{
     private Animation animacion;
	 public PuertaRota puertarota;
	 int lol;

    void Start()
    {
        animacion = GetComponent<Animation>();
    }

    public void OnTriggerEnter(Collider player)//sacarlo
    {
            puertarota.Cae();
			animacion.Play("TechoCae");
    }
}
