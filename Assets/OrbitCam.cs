using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbitCam : MonoBehaviour
{

    public float distance= 10;

    public Slider xSlider;
    public Slider ySlider;

    private void Awake()
    {
        xSlider.value = 0;
        ySlider.value = 15;
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(Time.deltaTime * xSlider.value, Time.deltaTime * ySlider.value, 0);
        transform.position = -transform.forward * distance;
    }

    public void StopCamera()
    {
        xSlider.value = 0;
        ySlider.value = 0;
    }

    public void ResetCamera()
    {
        transform.eulerAngles = Vector3.zero;
        transform.position = -transform.forward * distance;
        xSlider.value = 0;
        ySlider.value = 15;
    }
}
