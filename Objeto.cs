using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public bool EsAgarrable = true;
	public AgarrarObjeto agarrarobjeto;
	public bool tirar;
    
	void Update()
    {
		tirar = agarrarobjeto.tirar;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "PlayerMano")
		{
			other.GetComponentInParent<AgarrarObjeto>().Obj = this.gameObject;
			agarrarobjeto = other.GetComponentInParent<AgarrarObjeto>();
		}
		if(other.tag == "enemigo" && tirar == true)
		{
			other.GetComponentInParent<Monstruo>().golpe = true;
		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "PlayerMano")
		{
			other.GetComponentInParent<AgarrarObjeto>().Obj = null;
		}
	}
	
}
