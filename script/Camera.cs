using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target; // Pemain yang diikuti
    public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera
    public Vector3 offset; // Jarak relatif antara kamera dan pemain

    void LateUpdate()
    {
        if (target != null)
        {
            // Menghitung posisi target dengan offset
            Vector3 desiredPosition = target.position + offset;

            // Menghitung posisi kamera dengan smoothing
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Mengatur posisi kamera
            transform.position = smoothedPosition;
        }
    }
}
