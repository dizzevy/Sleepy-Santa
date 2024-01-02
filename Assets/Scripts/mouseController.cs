using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseController : MonoBehaviour
{
    public float xSent;
    public float ySent;
    public Transform playerBody;
    float xRotate;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSent * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySent * Time.deltaTime;

        xRotate += mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotate, 0, 0);

        playerBody.Rotate(Vector3.up, mouseX);
    }
}
