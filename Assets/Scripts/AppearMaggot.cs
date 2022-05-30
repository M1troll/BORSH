using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearMaggot : MonoBehaviour
{
    public GameObject Maggot;

    public void Appear()
    {
        var position = new Vector3(Random.Range(-1.8f, 1.65f), Random.Range(-4.85f, -2.15f));
        Instantiate(Maggot, position, new Quaternion(0, 0, 0, 0));
    }
}
