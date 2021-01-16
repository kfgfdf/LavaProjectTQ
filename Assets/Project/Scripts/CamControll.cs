using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControll : MonoBehaviour
{
    public float keyMoveSpeed;

    //public Transform cursorPoint;
    public Transform targetLook;
    public Camera camera;
    void Update()
    {
        if ((Input.GetAxisRaw ("Horizontal") != 0) || (Input.GetAxisRaw ("Vertical") != 0)) 
        {
            transform.position += new Vector3 (Input.GetAxisRaw ("Horizontal"), 0,
            Input.GetAxisRaw ("Vertical")) * Time.deltaTime * keyMoveSpeed;
        }

        RaycastHit hit;

        Ray myRay = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(myRay, out hit, 1000f))
        {
            Vector3 cursorPoint = hit.collider.transform.position;
            cursorPoint.y = 1f;
            targetLook.position = cursorPoint;
        }

    }
}
