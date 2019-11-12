using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class jugador : MonoBehaviour
{
    public Transform camara;
    public Linterna linterna;
	public Puerta puerta;
	public Puerta puerta1;
	public ControladorMenu menu;
	public Canvas Perder;
    public juego Juego;
    public GameObject enemigo;
    public float vida, energia, energiaMaxima, tpr, RunSpeed, WalkSpeed,timer,univida;
    public int kills,cpuerta;
    float tiempo,velc;
    public CharacterController cc;
    public FirstPersonController fpc;
	public GameObject Menu;
	public bool rad, perdio;

    public void Start()
    {
        energiaMaxima = 30;
        tpr = 2; 
        energia = 30;
        vida = 100;
        cpuerta = 0;
        velc = 1;
		Velocidad(3f, 6f);
		Perder.enabled = false;
		perdio = false;
        
    }

    void Update()
    {
		
		timer += Time.deltaTime;
		if(timer > 10f)
		{
			univida = ((vida % 100) % 10);
			if(univida < 9 && univida > 1)
		vida += (Time.deltaTime * 0.25f);
		}
		
		if(vida <= 0f && perdio == false)
			Morir();
		
        if(Input.GetButtonDown("Boton0"))
        {
            RaycastHit raycast;
            if (Physics.Raycast(camara.position, camara.forward, out raycast, 5f))
            {

                if (raycast.collider.gameObject.CompareTag("Manipular"))
                {
                    RaycastHit hit1;

                    if (Physics.Raycast(camara.position, camara.forward, out hit1))
                    {
                        Vector3 direccion = new Vector3(90, 0, 0);
                        Quaternion rotacion = Quaternion.LookRotation(direccion);
                        hit1.transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velc * Time.deltaTime);
                    }
                }
				
                if (raycast.collider.gameObject.CompareTag("Bateria"))
                    {
                        cpuerta++;
                        linterna.Bateria();
                        Destroy(raycast.collider.gameObject);
                    }
					
			    if (raycast.collider.gameObject.CompareTag("Llave"))
                {
					Destroy(raycast.collider.gameObject);
                    puerta.SumarLlave();
					puerta1.SumarLlave();
                }
                
            }
        }


		if (rad == false){
        if (Input.GetKey(KeyCode.LeftShift) && cc.velocity.magnitude >= 1f && energia >= 0)
        {

            energia -= Time.deltaTime;

            if (energia <= 0f)
            {
                energia = -tpr;
				Velocidad(1.5f, 1.5f);
            }
        }
        else
        {
            if (energia < energiaMaxima)
            {
                energia += Time.deltaTime;
                if (energia > 0)
                {
					Velocidad(3f, 6f);
                }
                else
                {
					Velocidad(1.5f, 2f);
                }
            }
        }
		}
        tiempo += Time.deltaTime;
    }

    public void RecibirDaño (float daño)
    {
        vida -= daño;
		timer = 0f;
    }
	 public void Velocidad (float v1, float v2)
    {
        WalkSpeed = v1;
        RunSpeed = v2;
    }
    public void Kills()
    {
        kills++;
    }
	
	public void Morir()
	{
		menu.pp = 1;
		perdio = true;
		menu.Pausa();	
		Perder.enabled = true;
	}

}
