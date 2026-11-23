
using UnityEngine;

public class MovimientoDestino : MonoBehaviour
{
    public Transform destino;
    public float velocidad = 4f;

    void Update()
    {
        // Calculamos el punto donde debe quedarse el dron:
        // justo encima de la plataforma.
        Vector3 posicionFinal = new Vector3(
            destino.position.x,
            destino.position.y + (destino.localScale.y / 2f) + (transform.localScale.y / 2f),
            destino.position.z
        );

        Vector3 direccion = posicionFinal - transform.position;
        float distancia = direccion.magnitude;

        if (distancia > 0f)
        {
            Vector3 movimiento = direccion.normalized * velocidad * Time.deltaTime;

            if (movimiento.magnitude >= distancia)
            {
                transform.position = posicionFinal;
            }
            else
            {
                transform.position += movimiento;
            }
        }
    }
}
