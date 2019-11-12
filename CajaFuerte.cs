using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CajaFuerte : MonoBehaviour
{
    public bool abierto,mostrar;
	public GameObject Ecerrado;
	public GameObject Eabierto;
	public Canvas Pantalla;
	public ControladorMenu Menu;
	string Codigo;
	string Usuario;
	public Text texto;
	public int cont,menu;
	
	
    void Start()
    {
        abierto = false;
		Eabierto.SetActive(false);
		Pantalla.enabled = false;
		mostrar = false;
		Codigo = "vlonder";
    }
    
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && abierto == false)
		{
				Menu.pp = 1;
				//Pantalla.enabled = true;
				Menu.MostrarF();
				Menu.Pausa();
				//Pausa();
				//Cambiar();
				//PP();
		}
	}
	
	
	public void Cambiar()
	{
		Pantalla.enabled = !Pantalla.enabled;
		//Menu.Pausa();
		//Menu.menu = menu;
	}
	
	public void Cerrar()
	{
		Pantalla.enabled = false;
		Menu.Pausa();
		Menu.pp = 0;
		//Menu.menu = menu;
	}
	
	public void PP()
	{
		Menu.Pausa();
	}
	
	public void Validar()
	{
		Usuario = texto.text;
		if(Usuario == Codigo)
		{
			Cerrar();
			Abrir();
			abierto = true;
		}
		else
		{
			texto.text = "incorrecto";
		}
	}
	public void Abrir()
	{
		abierto = true;
		Eabierto.SetActive(true);
		Ecerrado.SetActive(false);
	}
	
	public void Pausa()
	{
		if (menu == 0)
		menu = 1;
		else
		{
		menu = 0;
		}
		Menu.menu = menu;
	}
}
