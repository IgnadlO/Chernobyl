using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ControladorMenu : MonoBehaviour
{
	public Canvas canvas;
	public Canvas OP;
	public Canvas Fuerte;
	public int menu, pp;
    public float sensibilidad;
	public Text sens;
	public Slider barra;
	public Almacen almacen;
	public GameObject Almacen;
	public bool copiar;
	
    void Start()
    {
		Almacen = GameObject.Find("Almacen");
		almacen = Almacen.GetComponent<Almacen>(); 
		//canvas.enabled = false;
		OP.enabled = false;
		menu = 0;
		pp = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pp == 0)
		{
			Pausa();	
			Mostrar();			
        }
		
		copiar = almacen.copiar;
		if(copiar == true)
			sensibilidad = almacen.sens;
    }
	
	public void CargaNivel(string NombreNivel){
		if(NombreNivel == "Interior Casa")
		almacen.sens = sensibilidad;
	    almacen.copiar = true;
	SceneManager.LoadScene(NombreNivel);
	canvas.enabled = false;
	}		
	
	public void Pausa()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		if (menu == 0)
		menu = 1;
		else
		{
		menu = 0;
		Time.timeScale = 1f;
		}
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}
	
	public void Mostrar()
	{
	canvas.enabled= !canvas.enabled;
	}		
	
	public void MostrarF()
	{
	Fuerte.enabled= !Fuerte.enabled;
	}		
	
	public void MostrarOP()
	{
		canvas.enabled= !canvas.enabled;
		OP.enabled= !OP.enabled;
		
	}
	public void Salir(){
		Application.Quit();
	}
	
	public void CambioValor()
	{
		sensibilidad = barra.value;
		sens.text = (sensibilidad.ToString());
	}
}
