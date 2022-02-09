using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
    private bool        r_GyroEnabled;
    private Gyroscope   m_Gyro;
    private GameObject  m_CameraContainer;
    private Quaternion  m_Rot;

    private void Start()
    {
        m_CameraContainer = new GameObject("Camera Container");
        m_CameraContainer.transform.position = transform.position;
        transform.SetParent(m_CameraContainer.transform);
        r_GyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            m_Gyro = Input.gyro;
            m_Gyro.enabled = true;
            m_CameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            m_Rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    private void Update()
    {
        if (r_GyroEnabled)
        {
            transform.localRotation = m_Gyro.attitude * m_Rot;
        }
    }
}
