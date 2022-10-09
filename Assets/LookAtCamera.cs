using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    private Camera camera;
    private void Awake()
    {
        camera = (Camera)FindObjectOfType(typeof(Camera));
    }
    private void FixedUpdate()
    {
        transform.LookAt(camera.transform.position);
        transform.LookAt(transform.position - transform.forward);
    }
}
