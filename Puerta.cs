using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Collider player;
    public bool estado=true;
    private Animation animacion;
	public int llaves, cerradura, tipopuerta;
	public Estados son;
	public bool mostrar;
	public GameObject mapa;

    void Start()
    {
        animacion = GetComponent<Animation>();
		llaves = 0;
		Cambiar();
    }

    void Update()
    {
	if (Input.GetKeyDown(KeyCode.P))
        {
			SumarLlave();
        }
		
		if(Input.GetButtonDown("Boton3") && llaves >= 2f)
			{
				mostrar = !mostrar;
					Cambiar();
			}
    }
    public void OnTriggerStay(Collider player)
    {
        if(Input.GetButtonDown("Boton0"))
        {
			if(llaves >= cerradura)
            Estado();
        }
    }
    public void Estado()
    {
        if (0 == transform.localRotation.y)
        {
			if(tipopuerta==1)
				animacion.Play("AbrirBunker");
			else
                animacion.Play("AbrirPuerta");
        }
        else       
        {
			if(tipopuerta==1)
				animacion.Play("CerrarBunker");
			else
                animacion.Play("CerrarPuerta");
        }
		
		if(llaves == 2)
			son.UltimaCancion();
    }
	
    public void SumarLlave(){
		llaves++;
	}
	
	public void Cambiar()
	{
		if (mostrar == false) mapa.SetActive(false);
		if (mostrar == true) mapa.SetActive(true);
	}
}
