using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 2.0f;

    void Update()
    {
        // Gerakan WASD (Hanya aktif jika klik kanan ditahan)
        if (Input.GetMouseButton(1))
        {
            float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            float moveY = 0;

            if (Input.GetKey(KeyCode.E)) moveY = speed * Time.deltaTime; // Naik
            if (Input.GetKey(KeyCode.Q)) moveY = -speed * Time.deltaTime; // Turun

            transform.Translate(moveX, moveY, moveZ);

            // Rotasi Mouse
            float rotateX = Input.GetAxis("Mouse X") * sensitivity;
            float rotateY = Input.GetAxis("Mouse Y") * sensitivity;
            transform.Rotate(-rotateY, rotateX, 0);

            // Koreksi agar kamera tidak miring (roll)
            Vector3 currentRot = transform.localEulerAngles;
            currentRot.z = 0;
            transform.localEulerAngles = currentRot;
        }
    }
}