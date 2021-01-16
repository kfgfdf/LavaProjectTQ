using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAim : MonoBehaviour
{
    private Animator animPlayer;
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        animPlayer = Player.GetComponent<Animator>();
    }

    void OnTriggerEnter (Collider other)
    {
     if(other.gameObject.tag == "Player")
        {
            animPlayer.SetBool("isZombie", true);
        }
    }
    void OnTriggerExit (Collider other)
    {
     if(other.gameObject.tag == "Player")
        {
            animPlayer.SetBool("isZombie", false);
        }
    }
}
