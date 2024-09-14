using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            // Obtener la posición actual de la cámara
            Vector3 newPosition = transform.position;

            // Centrar la cámara horizontalmente en el jugador
            newPosition.x = target.position.x;

            // Mover la cámara hacia la posición vertical del jugador, manteniendo la misma altura
            newPosition.y = target.position.y;

            // Asignar la nueva posición a la cámara
            transform.position = newPosition;
        }
    }
}
