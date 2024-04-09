using UnityEngine;

public class GyroController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    private Rigidbody rb;
    private bool gyroEnabled;
    private Gyroscope gyro;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Verificar si el dispositivo tiene giroscopio
        gyroEnabled = SystemInfo.supportsGyroscope;

        if (gyroEnabled)
        {
            // Habilitar el giroscopio
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        else
        {
            Debug.LogWarning("El dispositivo no tiene giroscopio.");
        }
    }

    void Update()
    {
        // Movimiento con las teclas WASD
        float moveHorizontal = Input.GetAxis("Horizontal"); // Obtener entrada horizontal (A y D)
        float moveVertical = Input.GetAxis("Vertical"); // Obtener entrada vertical (W y S)

        // Calcular el movimiento desde el teclado
        Vector3 keyboardMovement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Movimiento con el giroscopio
        Vector3 gyroMovement = Vector3.zero;

        if (gyroEnabled)
        {
            // Obtener la velocidad del giroscopio
            gyroMovement = new Vector3(-gyro.attitude.x, 0, -gyro.attitude.y);
        }

        // Combinar ambos movimientos
        Vector3 movement = keyboardMovement + gyroMovement;

        // Normalizar el movimiento si es necesario para evitar velocidades excesivas
        if (movement.magnitude > 1)
            movement.Normalize();

        // Aplicar el movimiento a la pelota
        rb.AddForce(movement * moveSpeed);
    }
}
