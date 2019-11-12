using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public Transform vent;
    float giro = 0, timer = 0;
    private void Update()
    {
        giro += 1;
        if (giro >= 179)
           giro = -180;
        timer++;

        Vector3 xyz = new Vector3(0, giro, 0);
        vent.localEulerAngles = Vector3.Lerp(vent.localEulerAngles, xyz, timer);
    }
}
