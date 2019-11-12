using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alerta : MonoBehaviour
{
	public float velocidadGiroBusqueda = 120f;
    public float duracionBusqueda = 4f;

    private Estados estados;
    private ControladorNavMesh agente;
    private ControladorVision vision;
    private float tiempoBuscando;

	void Awake () {
        estados = GetComponent<Estados>();
        agente = GetComponent<ControladorNavMesh>();
        vision = GetComponent<ControladorVision>();
	}

    void OnEnable()
    {
        agente.DetenerAgente();
        tiempoBuscando = 0f;
    }
	
	void Update () {
        RaycastHit hit;
        if (vision.PuedeVerAlJugador(out hit))
        {
            agente.perseguirOjetivo = hit.transform;
            estados.ActivarEstado(estados.Perseguir);
            return;
        }
        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;
        if(tiempoBuscando >= duracionBusqueda)
        {
            estados.ActivarEstado(estados.Patrulla);
            return;
        }
	}
}
