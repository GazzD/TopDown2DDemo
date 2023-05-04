using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // referencia al objeto player
    public float speed = 1f; // velocidad a la que se mueve el enemigo
    public float visionRadius = 10f; // radio del campo de visión del enemigo
    private Rigidbody2D rb;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Calcular la distancia y dirección del jugador
        Vector2 direction = (Vector2)player.position - rb.position;
        float distance = direction.magnitude;

        // Si el jugador está dentro del campo de visión
        if (distance <= visionRadius)
        {
            direction.Normalize();
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero; // Detener el movimiento del enemigo si el jugador está fuera del campo de visión
        }
    }

    // Dibujar el campo de visión del enemigo en el editor de Unity para fines de depuración
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
