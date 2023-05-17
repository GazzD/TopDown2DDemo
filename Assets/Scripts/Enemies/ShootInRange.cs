using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInRange : MonoBehaviour
{
    public Transform player; // referencia al objeto player
    public float speed = 1f; // velocidad a la que se mueve el enemigo
    public float shootRadius = 5f; // radio del campo de visi�n del enemigo
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
        // Calcular la distancia y direcci�n del jugador
        Vector2 direction = (Vector2)player.position - rb.position;
        float distance = direction.magnitude;

        // Si el jugador est� dentro del campo de disparo
        if (distance <= shootRadius)
        {
            print("shoot");
        }
    }

    // Dibujar el campo de visi�n del enemigo en el editor de Unity para fines de depuraci�n
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootRadius);
    }
}
