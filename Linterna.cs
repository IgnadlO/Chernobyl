using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public float bateria;
    public GameObject luz;
	public Scrollbar barra;

    void Update()
    {
        if (luz.activeSelf)
            bateria -= Time.deltaTime;

        if (bateria <= 0) 
            luz.SetActive(false);

        if (bateria > 100)
            bateria = 100;

        if (Input.GetButtonDown("Boton2") && bateria > 0)
            luz.SetActive(!luz.activeSelf);
		barra.size = bateria/100f;
    }
    public void Bateria()
    {
        bateria += 40;
    }
}
