using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
	public GameObject Obj;
	public GameObject ObjActual;
	public GameObject ObjTirado;
	public Transform Dest;
	public Transform Mano;
	public float vel = 6f,timer;
	public Rigidbody proyectil;
	public bool tirar = false;
	public Vector3 Punto;
	
	
    void Update()
    {
       if(Obj != null && ObjActual == null) 
	   {
		  if(Input.GetButtonDown("Boton0"))
		  {
			Agarrar();
		  }			  
	   }
	   else if (ObjActual != null)
	   {
		   if(Input.GetButtonDown("Boton1"))
		  {
			Lanzar();
		  }		
	   }
	   if (tirar == true)
		   timer += Time.deltaTime;
	   ObjTirado.transform.position = Vector3.Lerp(ObjTirado.transform.position, Punto, Mathf.Abs(Time.deltaTime * vel));
	   if((ObjTirado.transform.position == Punto) || (timer > 1.1f))
	   {
		   tirar = false;
		   ObjTirado.GetComponent<Rigidbody>().useGravity = true;
		   ObjTirado.transform.SetParent(null);
		   ObjTirado = null;
	   }
		   
    }
	public void Agarrar()
	{
			ObjActual = Obj;	
			proyectil = ObjActual.GetComponent<Rigidbody>();
			ObjActual.GetComponent<Objeto>().EsAgarrable = false;
			ObjActual.transform.SetParent(Mano);
			ObjActual.transform.position = Mano.position;
			ObjActual.transform.rotation = Mano.rotation;
			ObjActual.GetComponent<Rigidbody>().useGravity = false;
			ObjActual.GetComponent<Rigidbody>().isKinematic = true;
	}
	
	/*public void Soltar()
	{
			ObjActual.GetComponent<Objeto>().EsAgarrable = true;
			ObjActual.GetComponent<Rigidbody>().useGravity = true;
			ObjActual.GetComponent<Rigidbody>().isKinematic = false;
			ObjActual = null;
	}
	*/
	
	public void Lanzar()
	{
			tirar = true;
			timer = 0f;
			ObjActual.GetComponent<Objeto>().EsAgarrable = true;
			ObjActual.transform.SetParent(null);
			ObjActual.GetComponent<Rigidbody>().isKinematic = false;
			Punto = new Vector3(Dest.position.x,Dest.position.y - 0.5f,Dest.position.z);
			//ObjActual.GetComponent<Rigidbody>().useGravity = true;
			ObjTirado = ObjActual;
			ObjActual = null;
			ObjTirado.transform.position += Vector3.up;
            //ObjActual.transform.position = Dest.position;
		 
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag != "PlayerMano")
		{
			tirar = false;
		}
	}
}
