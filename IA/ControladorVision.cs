using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorVision : MonoBehaviour
{
    public Transform Ojos;
	public float rangoVision = 10f;
	public Vector3 offset = new Vector3(0f, 0.75f, 0f);
	private ControladorNavMesh controladorNavMesh;
	
	void Awake()
	{
		controladorNavMesh = GetComponent<ControladorNavMesh>();
	}
	public bool PuedeVerAlJugador(out RaycastHit hit, bool mirarHaciaElJugador = true)
	{
		Vector3 vectorDireccion;
		if(mirarHaciaElJugador)
		{
			vectorDireccion = (controladorNavMesh.perseguirOjetivo.position + offset) - Ojos.position;
		}else
		{
			vectorDireccion = Ojos.position;
		}
		//if(hit.collider.CompareTag("Player")) ver = true;
		//else ver = false;
		
		Debug.DrawLine (Ojos.position, vectorDireccion, Color.white);
		return Physics.Raycast(Ojos.position, vectorDireccion, out hit, rangoVision) && hit.collider.CompareTag("Player");
	}
	
} 
