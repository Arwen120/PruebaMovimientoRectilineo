
using UnityEngine;

public class MovimientoRigidbody25m : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaMaxima = 25f;

    private Rigidbody rb;
    private Vector3 posicionInicial;
    private Vector3 direccion;
    private bool detenido = false;

    void Start()
    {
       
            rb = GetComponent<Rigidbody>();

            posicionInicial = rb.position;
            direccion = transform.forward.normalized;

        Debug.Log("Rigidbody encontrado: " + (rb != null));
        Debug.Log("Velocidad configurada: " + velocidad);
        rb.linearVelocity = new Vector3(0, 0, 5);
        Debug.Log("Velocidad inicial: " + rb.linearVelocity);

    }

    void FixedUpdate()
    {
        if (!detenido)
        {
            Debug.Log("Velocidad: " + rb.linearVelocity);

            float distanciaRecorrida =
                Vector3.Dot(rb.position - posicionInicial, direccion);

            if (distanciaRecorrida >= distanciaMaxima)
            {
                Debug.Log("Ha alcanzado la distancia máxima");

                Vector3 posicionFinal = posicionInicial +
                    direccion * distanciaMaxima;

                posicionFinal.y = rb.position.y;

                rb.position = posicionFinal;
                Detener();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Debug.Log("Impacto");
            Debug.Log("Objeto que ha provocado la colisión: " + collision.gameObject.name);
            Detener();
        }
    }

    void Detener()
    {
        detenido = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
