using UnityEngine;

public class BeybladeController : MonoBehaviour
{
    public float gyroSensitivity = 1.0f; // Sensibilidad del giroscopio
    public float movementSpeed = 5.0f; // Velocidad de movimiento con los controles WASD

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Control con giroscopio
        Vector3 gyroInput = new Vector3(Input.gyro.rotationRateUnbiased.x, 0, Input.gyro.rotationRateUnbiased.y);
        rb.AddTorque(gyroInput * gyroSensitivity);

        // Control con WASD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * movementSpeed);
    }

    void FixedUpdate()
    {
        // Asegurarse de que el Beyblade no se caiga
        rb.rotation = Quaternion.Euler(0, rb.rotation.eulerAngles.y, 0);
    }
}
