using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTower : MonoBehaviour
{
    public Animator animPlayer;
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        animPlayer = Player.GetComponent<Animator>();
    }

    void OnTriggerEnter (Collider other)
    {
     if(other.gameObject.tag == "Player")
        {
            animPlayer.SetBool("isTower", true);
        }
    }
    void OnTriggerExit (Collider other)
    {
     if(other.gameObject.tag == "Player")
        {
            animPlayer.SetBool("isTower", false);
        }
    }
}
