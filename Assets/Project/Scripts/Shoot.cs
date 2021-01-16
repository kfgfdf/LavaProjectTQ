using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootPoint;
    public void Shooting()
    {
        Instantiate(Bullet, shootPoint.transform.position, shootPoint.transform.rotation);
    }
}
