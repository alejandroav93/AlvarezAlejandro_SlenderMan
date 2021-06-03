using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC : MonoBehaviour
{
    // Start is called before the first frame update
    LevelManager manager;
    void Start()
    {
        manager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()

    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray camRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(camRay, out hitInfo) && Input.GetMouseButtonDown(0))
        {
            if (hitInfo.collider.CompareTag("Obstacle"))
            {
                Destroy(hitInfo.collider.gameObject);
                manager.Score++;
            }
        }
        /*
        Debug.DrawRay(camRay.origin, camRay.direction, Color.red);
            */
        /*
        RaycastHit hitInfo;

        if(Physics.Raycast(transform.position, Vector3.down, out hitInfo, 3)){
            hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        */

        /*
        Color hit = Physics.Raycast(transform.position, Vector3.down, 3) ?
            Color.green : Color.red;
        Debug.DrawRay(transform.position, Vector3.down * 3, hit);
        */
    }

}
