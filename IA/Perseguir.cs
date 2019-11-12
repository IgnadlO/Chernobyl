using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseguir : MonoBehaviour
{
	private Estados estados;
	private ControladorNavMesh agente;
	private ControladorVision vision;
	float timer = 0;
	
    void Awake()
    {
       estados = GetComponent<Estados>(); 
       agente = GetComponent<ControladorNavMesh>(); 
	  vision = GetComponent<ControladorVision>(); 
    }

    void Update()
    {
		RaycastHit hit;
		if(!vision.PuedeVerAlJugador(out hit, true))
		{
			timer += Time.deltaTime;
			if(timer >= 10f)
			{
			timer = 0;
			estados.ActivarEstado(estados.Patrulla);
			return;
			}
		}
        agente.ActualizarPuntoN();
		
            
    }
}
