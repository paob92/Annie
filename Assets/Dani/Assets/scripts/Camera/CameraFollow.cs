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
            // Obtener la posici�n actual de la c�mara
            Vector3 newPosition = transform.position;

            // Centrar la c�mara horizontalmente en el jugador
            newPosition.x = target.position.x;

            // Mover la c�mara hacia la posici�n vertical del jugador, manteniendo la misma altura
            newPosition.y = target.position.y;

            // Asignar la nueva posici�n a la c�mara
            transform.position = newPosition;
        }
    }
}
