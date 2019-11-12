using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estados : MonoBehaviour
{
    public MonoBehaviour Patrulla;
	public MonoBehaviour Alerta;
	public MonoBehaviour Perseguir;
	public MonoBehaviour Inicial;
	public MonoBehaviour Actual;
	public Monstruo Monstruo;
	public AudioSource sonido0;
	public AudioSource sonido1;
	public AudioSource sonido2;
	public int ne;
	public bool ult = false;
    void Start()
    {
       ActivarEstado(Inicial); 
	   sonido2.Stop();
	   sonido1.Stop();
    }

    void Update()
    {
        
    }
	public void ActivarEstado(MonoBehaviour nuevoEstado)
	{
		if(Actual!=null) Actual.enabled = false;
		Actual = nuevoEstado;
		Actual.enabled = true;
		if(Actual == Patrulla) 
		{
			ne = 1;
			if(ult == false && !sonido0.isPlaying)
			{
			sonido0.Play();
			sonido1.Stop();
			}
		}
		else if(Actual == Perseguir) 
		{
			ne = 2;
			if(ult == false)
			{
			sonido1.Play();
			sonido0.Stop();
			}
		}
		else ne = 3;
		Monstruo.CalcVel(ne);
    }
	
	public void UltimaCancion()
	{
		if(!sonido2.isPlaying) sonido2.Play();
		ult = true;
		sonido1.Stop();
		sonido0.Stop();
	}
}
