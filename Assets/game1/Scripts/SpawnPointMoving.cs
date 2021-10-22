using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMoving : MonoBehaviour
{
    Vector3 pointA = new Vector3(-175, 101,0);
    Vector3 pointB = new Vector3(823, 101);
    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
    }
}
