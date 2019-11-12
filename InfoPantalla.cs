using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPantalla : MonoBehaviour
{
	public Radiacion rad;
	public Monstruo mon;
	public jugador jugador;
	public Linterna linterna;
	public ControladorMenu menu;
	
	public float vida, prad, velm, energia, bat;	
	public Text radt,mont,enet,vidat,batt;

    void Update()
    {
        prad = rad.prad;
		vida = jugador.vida;
		velm = mon.vel;
		energia = menu.sensibilidad;
		bat = linterna.bateria;
		
		radt.text = ("P. radiacion " + prad.ToString());
		mont.text = ("Vel del Monstruo " + velm.ToString());
		enet.text = ("Sensibilidad " + energia.ToString());
		vidat.text = ("Vida " + vida.ToString());
		batt.text = ("Bateria " + bat.ToString());
    }
}
