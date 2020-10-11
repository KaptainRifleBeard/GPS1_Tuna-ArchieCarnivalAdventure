using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        }
    }
}

//transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
   