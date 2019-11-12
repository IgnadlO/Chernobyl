using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nota : MonoBehaviour
{
	public bool mostrar = false;
	public GameObject nota;
	
	void Start()
	{
		Cambiar();
	}
    private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			if(Input.GetButtonDown("Boton0"))
			{
				mostrar = !mostrar;
					Cambiar();
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			mostrar = false;
			Cambiar();
		}
	}
	
	public void Cambiar()
	{
		if (mostrar == false) nota.SetActive(false);
		if (mostrar == true) nota.SetActive(true);
	}
}
