
using UnityEngine;

public class MovimientoDestinoRigidbody : MonoBehaviour
{
    public Transform destino;
    public float velocidad = 4f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 posicionFinal = new Vector3(
            destino.position.x,
            destino.position.y + (destino.localScale.y / 2f) + (transform.localScale.y / 2f),
            destino.position.z
        );

        Vector3 direccion = posicionFinal - rb.position;
        float distancia = direccion.magnitude;

        if (distancia > 0f)
        {
            Vector3 movimiento = direccion.normalized * velocidad * Time.fixedDeltaTime;

            if (movimiento.magnitude >= distancia)
            {
                rb.MovePosition(posicionFinal);
            }
            else
            {
                rb.MovePosition(rb.position + movimiento);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destino"))
        {
            Debug.Log("Paquete entregado");
        }
    }
}
