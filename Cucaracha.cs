using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucaracha : MonoBehaviour
{
    public float vel;
    float m, de, ab, esp;
    public float alto, ancho;
    Vector3 direccion;
    Vector3 ndir;
    Vector3 cmirar = new Vector3(0, 0, 90f);
    Vector3 ajustar;

    void Start()
    {

        m = 0;
        Mover();
        de = ancho * -1;
        ab = alto * -1;
        ajustar = transform.position;
    }

    void Update()
    {
        switch (m)
        {
            case 1:
                if (ndir.y <= transform.position.y)
                {
                    Mover();
                    Mirar();
                }
                break;
            case 2:
                if (ndir.x >= transform.position.x)
                {
                    Mover();
                    Mirar();
                }
                break;
            case 3:
                if (ndir.y >= transform.position.y)
                {
                    Mover();
                    Mirar();
                }
                break;
            case 4:
                if (ndir.x <= transform.position.x)
                {
                    Mover();
                    Mirar();
                }
                break;
            default:
                m = 0;
                Mover();
                transform.position = ajustar;
                break;
        }
        esp += 0.1f;
        if (esp < 50)
            transform.position += direccion.normalized * vel * Time.deltaTime;
        else
        {
            if (esp >= 60)
                esp = 0;
        }
    }
    void Mover()
    {
        m++;
        if (m == 1)
            direccion = new Vector3(0, alto, 0f);
        if (m == 2)
            direccion = new Vector3(de, 0, 0);
        if (m == 3)
            direccion = new Vector3(0, ab, 0);
        if (m == 4)
            direccion = new Vector3(ancho, 0, 0);
        ndir = transform.position + direccion;
    }
    void Mirar()
    {
        transform.Rotate(cmirar);
    }

}
