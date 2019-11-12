using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monstruo : MonoBehaviour
{
	public float vel;
	float r,timer;
	int est;
	public bool golpe;
	private UnityEngine.AI.NavMeshAgent agente;
	private Estados estados;
	public jugador jugador;
	
    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
		estados = GetComponent<Estados>();
    }

    void Update()
    {
		if(golpe == true)
		{
			CalcVel(est,true);
			timer += Time.deltaTime;
			if (timer > 5f)
			{
				timer = 0f;
				CalcVel(est,false);
				golpe = false;
			}
		}
    }
	
	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player" && golpe == false)
		{
			if(estados.Actual == estados.Perseguir)
			{
				jugador.RecibirDaño(Time.deltaTime * 3f);
			}
		}
	}
	
	public void CalcVel(int estado, bool aturdir = false)
	{		
		est = estado;
		if(aturdir == true) 
			vel = 0f;
		else
		{
		if(estado == 1) vel = (2f + r);
		if(estado == 2) vel = (3f + r);
		}
		
		agente.speed = vel;
	}
	
	public void Radiacion(bool rad)
	{
		if (rad == true) r = 0.5f;
        else r = 0f;	
		CalcVel(est);
	}
}
