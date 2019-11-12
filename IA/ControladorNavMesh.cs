using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour
{
   private UnityEngine.AI.NavMeshAgent agente;
   public Transform perseguirOjetivo;
   
    void Awake()
    {
        agente=GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	public void ActualizarPunto(Vector3 puntoDestino){
		agente.destination = puntoDestino;
		agente.isStopped = false;
	}
	public void ActualizarPuntoN()
	{
		ActualizarPunto(perseguirOjetivo.position);
	}
	public void DetenerAgente()
	{
		agente.isStopped = true;
	}
	public bool Llego()
	{
	 return	agente.remainingDistance <= agente.stoppingDistance && !agente.pathPending;
	}
}
