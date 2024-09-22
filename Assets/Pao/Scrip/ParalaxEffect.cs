using System.Collections;
using System.Collections.Generic;
using UnityEditor.Analytics;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplayer;

    private Transform cameraTransform;
    private Vector3 previousCameraPosition;//posición de la camara 
    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;//le asigno posición de la camara 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - previousCameraPosition.x)*parallaxMultiplayer ;//para calcular diferencia de movimiento de la camara
        float deltaY  = (cameraTransform.position.y - previousCameraPosition.y)* parallaxMultiplayer;//para calcular diferencia de movimiento de la camara
        transform.Translate(new Vector3(deltaX,deltaY , 0));
        previousCameraPosition = cameraTransform.position;

    }
}
