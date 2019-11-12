using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escapar : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			if(Input.GetButtonDown("Boton0"))
			{
			SceneManager.LoadScene("Ganar");
			}
		}
	}
}
