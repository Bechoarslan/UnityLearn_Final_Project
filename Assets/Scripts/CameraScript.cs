using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        
        

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position - new Vector3(0,-5,7 );
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
}
