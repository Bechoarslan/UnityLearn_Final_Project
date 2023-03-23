using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    private Camera cam;
    // Start is called before the first frame update
   private  void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
   private void LateUpdate()
    {
        offset = new Vector3(1.42f, 1.13f, 0);
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.position != pos)
        {
            transform.position = pos;
        }
        
    }
}
