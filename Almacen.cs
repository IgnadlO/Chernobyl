using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almacen : MonoBehaviour
{
	public float sens;
	public bool copiar;

	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	

	
}
