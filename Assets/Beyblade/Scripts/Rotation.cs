using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Velocidad de rotación

    public Vector3 rotationAxis = Vector3.up; // Eje de rotación

    void Update()
    {
        // Rotar el GameObject alrededor del eje especificado a la velocidad deseada
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
