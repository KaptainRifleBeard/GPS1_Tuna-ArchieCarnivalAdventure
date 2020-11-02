using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        var zoom = 4.4f;
        Camera.main.orthographicSize = zoom;        
    }

}
    