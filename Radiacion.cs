using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radiacion : MonoBehaviour
{
    public Transform player,monstruo;
    public float dm, sdm, rad, prad, sprad;
    float timer;
    int alu=0,fps,i;
	public float[] distancia;
	public float[] sdistancia;
	public Transform[] focos;
    public bool ealu;
	public jugador jugador; 
	public Monstruo pepe;
	public Color color = new Color(5f, 31f, 4f, 1f);
	public GameObject Rojo;
	public GameObject Verde;
	public AudioSource sonido;

    void Start()
    {
        fps = 75;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fps; 
		sonido = GetComponent<AudioSource>();
    }

    void Update()
    {
		for (i = 0; i < focos.Length; i++)
		{
		distancia[i] = Vector3.Distance(focos[i].transform.position, player.transform.position);
		sdistancia[i] = Vector3.Distance(focos[i].transform.position, monstruo.transform.position);
		}
		dm = distancia[0];
		sdm = sdistancia[0];
		for(i = 0; i < distancia.Length; i++)
		{
			if (distancia[i] < dm) dm = distancia[i];
			if (sdistancia[i] < sdm) sdm = sdistancia[i];
		}
		
		if (sdm <= 11) sprad = CalcRad(sdm);
        if (dm <= 11) prad = CalcRad(dm);
        else prad = 33;
		
        rad = (prad * 30) / 100;
        if (prad >= 90) timer += Time.deltaTime;
		
        if (timer>=5 && ealu == false)
        {
                Alucinacion();
        }
        if (Application.targetFrameRate != fps)
            Application.targetFrameRate = fps;
		
		if (sprad > 60) pepe.Radiacion(true);
		else pepe.Radiacion(false); 
		
		if (prad > 60) Sufrir();		
		else
		{			
	    sonido.Stop();
	    jugador.rad=false;
		Rojo.SetActive(false);
		Verde.SetActive(true);	  
		}
		
		CPanel();
    }
    
    public float CalcRad(float dmp)
    {
        float prad=100f;
        if (dmp <= 2f)
            dmp = 0;
        else
            dmp = dmp * 5.91f;
        prad -= dmp;
        return prad;
    }
	void Sufrir()
	{
		if(!sonido.isPlaying)
		sonido.Play();
		jugador.RecibirDaño(Time.deltaTime * (rad/12));
		jugador.rad=true;
		jugador.Velocidad((3f-(rad/20)),(6f-(rad/15)));
		Rojo.SetActive(true);
		Verde.SetActive(false);
	}
    void Alucinacion()
    {
        ealu = !ealu;
        timer = 0;
        alu++;
        fps = 30;

    }
	public void CPanel()
	{
		Image Panel =  GameObject.Find("Panel").GetComponent<Image>();
		Color color = new Color(0.01896388f, 0.1226415f, 0.01561944f, ((prad * 0.6705882f)/100f));
		Panel.color = color;
	}
}
