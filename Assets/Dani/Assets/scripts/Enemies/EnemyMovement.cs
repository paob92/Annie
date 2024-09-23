using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private Transform[] movementPoints;  // Puntos de destino
    [SerializeField] private float movementSpeed = 2f;    // Velocidad de movimiento
    [SerializeField] private float minDistance = 0.1f;    // Distancia mínima para cambiar de punto
    private int currentPointIndex = 0;                    // Índice del punto actual

    private void Start()
    {
        // Asegurarse de que el objeto comience moviéndose hacia el primer punto
        if (movementPoints.Length > 0)
        {
            currentPointIndex = 0;
        }
    }

    private void Update()
    {
        if (movementPoints.Length == 0) return; // Salir si no hay puntos asignados

        // Mover el objeto hacia el punto actual
        MoveTowardsPoint();

        // Si el objeto ha llegado suficientemente cerca del punto de destino
        if (Vector2.Distance(transform.position, movementPoints[currentPointIndex].position) < minDistance)
        {
            // Cambiar al siguiente punto
            GetNextPoint();
        }
    }

    private void MoveTowardsPoint()
    {
        // Moverse hacia el punto actual usando MoveTowards
        transform.position = Vector2.MoveTowards(transform.position, movementPoints[currentPointIndex].position, movementSpeed * Time.deltaTime);
    }

    private void GetNextPoint()
    {
        // Elegir el siguiente punto en la secuencia (volver al inicio si se llega al final)
        currentPointIndex++;
        if (currentPointIndex >= movementPoints.Length)
        {
            currentPointIndex = 0; // Reiniciar ciclo
        }

        // Opcional: Invertir escala en X para simular un cambio de dirección
        if (transform.position.x < movementPoints[currentPointIndex].position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z); // Mirar a la derecha
        }
        else
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z); // Mirar a la izquierda
        }
    }

}
