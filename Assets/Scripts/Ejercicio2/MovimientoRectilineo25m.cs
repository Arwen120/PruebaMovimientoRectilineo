
using UnityEngine;

public class MovimientoRectilineo25m : MonoBehaviour
{
    public float velocidad = 5f;
    public float distanciaMaxima = 25f;

    private Vector3 posicionInicial;
    private Vector3 direccion;
    private float distanciaRecorrida = 0f;

    void Start()
    {
        posicionInicial = transform.position;
        direccion = transform.forward;
    }

    void Update()
    {
        if (distanciaRecorrida < distanciaMaxima)
        {
            float paso = velocidad * Time.deltaTime;

            float distanciaRestante = distanciaMaxima - distanciaRecorrida;

            if (paso >= distanciaRestante)
            {
                paso = distanciaRestante;
            }

            transform.position += direccion * paso;

            distanciaRecorrida += paso;
        }
    }
}
