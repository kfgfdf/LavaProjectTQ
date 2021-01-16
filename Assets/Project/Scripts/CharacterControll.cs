using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControll : MonoBehaviour
{
    public LayerMask WhatIsGround;
    public Camera cam;
    public GameObject Bullet;
    private NavMeshAgent myAgent;


    public Animator anim;

    private bool isAiming;

    public Shoot shoot;

    public Transform targetObject;
    public Transform ShootPoint;

    public ControllSpeed controllSpeed;
    private float periodShooting;
    private float nextActionTime;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.speed = controllSpeed.speedCharacter;

        periodShooting = controllSpeed.rateOfFire;
        nextActionTime = periodShooting;
    }

    void Update()
    {
        if(myAgent.hasPath)
        {
            float m = Mathf.Clamp01(controllSpeed.speedCharacter);
            anim.SetFloat("Blend", m, 0.15f, Time.deltaTime);
        }
        //else
        //    anim.SetFloat("Blend", 0);
        Vector3 dis = myAgent.destination - transform.position;
        if(dis.sqrMagnitude <= 0.3f)
            anim.SetFloat("Blend", 0);


        if(anim.GetBool("isTower") && anim.GetBool("isZombie"))
            isAiming = true;
        else
            isAiming = false;

        if(isAiming)
        {
        //      Ray rayy = cam.ScreenPointToRay (Input.mousePosition);
        //     RaycastHit hit = new RaycastHit();
        //     if (Physics.Raycast (rayy, out hit))
        //     {
        //         Vector3 rot = transform.eulerAngles;
        //         transform.LookAt(hit.point);
        //         transform.eulerAngles = new Vector3(rot.x, transform.eulerAngles.y - 90, rot.z);
        //     }
            transform.LookAt(targetObject);
            ShootPoint.transform.LookAt(targetObject);
            
        }

        if(Input.GetMouseButtonDown(0) && !isAiming)
        {
            Ray myRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;

            if(Physics.Raycast(myRay, out hitinfo, 100, WhatIsGround))
            {
                myAgent.SetDestination(hitinfo.point);   
            }   
        }
        // else if(Input.GetMouseButtonDown(0) && isAiming)
        // {
        //     if(Time.time > nextActionTime) 
        //     {
        //         nextActionTime += periodShooting;
        //         shoot.Shooting();
        //     }
        // }
        else if(Input.GetMouseButton(0) && isAiming)
        {
            if(Time.time > nextActionTime) 
            {
                nextActionTime += periodShooting;
                shoot.Shooting();
            }
        }
    }
}
