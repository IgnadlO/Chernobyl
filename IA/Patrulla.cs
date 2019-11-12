using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour
{
	public Transform[] WayPoints;
	private ControladorVision vision;
	private Estados estados;
	private int sigpunto;
	private ControladorNavMesh agente;

    void Awake()
    {
	   estados = GetComponent<Estados>(); 
       agente = GetComponent<ControladorNavMesh>(); 
	   vision = GetComponent<ControladorVision>(); 
    }

    void Update()
    {
		RaycastHit hit;
		if(vision.PuedeVerAlJugador(out hit))
		{
			agente.perseguirOjetivo = hit.transform;
			estados.ActivarEstado(estados.Perseguir);
			return;
		}
        if(agente.Llego())
		{
			sigpunto = (sigpunto + 1) % WayPoints.Length;
			Actualizarwaypoint();
		}
    }
	void OnEnable()
	{
		Actualizarwaypoint();
	}
	void Actualizarwaypoint()
	{
		agente.ActualizarPunto(WayPoints[sigpunto].position);
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && enabled) 
		{
			estados.ActivarEstado(estados.Alerta);			
		}
	}
}
