using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rata : MonoBehaviour
{
    public float vel, velrot;
    public float radio, timer;
    public Vector3 npos;
    public Vector3 pos;

    void Calcularnpos()
    {
        npos = transform.position + Random.insideUnitSphere * radio;
        npos.y = 0;
    }

    void Start()
    {
        Calcularnpos();
        radio = 10f;
    }


    void Update()
    {
        timer += Time.deltaTime;
        pos = npos - transform.position;
        if (pos.magnitude < 0.5f || timer >= 20)
        {
            Calcularnpos();
            timer = 0;
        }
        Quaternion rotacion = Quaternion.LookRotation(pos, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacion, velrot * Time.deltaTime);
        transform.position += transform.forward * vel * Time.deltaTime;

        Debug.DrawLine(transform.position, npos, Color.green);
    }
}
