using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float movementSpeed = 10f;

    public float fastMovementSpeed = 100f;

    public float freeLookSensitivity = 3f;

    private bool looking = false;

    public Transform ceiling;
    public Transform leftWall;
    public Transform rightWall;
    public Transform floor;
    public Transform backWall;
    public Transform fwdWall;

    

    void Update()
    {
        var fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;

        if(transform.position.y > ceiling.position.y - 5)
        {
            gameObject.transform.position = new Vector3(transform.position.x, ceiling.position.y - 5, transform.position.z);
        }

        if (transform.position.y < floor.position.y + 5)
        {
            gameObject.transform.position = new Vector3(transform.position.x, floor.position.y + 5, transform.position.z);
        }

        if (transform.position.x < leftWall.position.x + 10)
        {
            gameObject.transform.position = new Vector3(leftWall.position.x + 10, transform.position.y , transform.position.z);
        }

        if (transform.position.x > rightWall.position.x - 10)
        {
            gameObject.transform.position = new Vector3(rightWall.position.x - 10, transform.position.y, transform.position.z);
        }

        if (transform.position.z > fwdWall.position.z - 10)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, fwdWall.position.z - 10);
        }

        if (transform.position.z < backWall.position.z + 10)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, backWall.position.z + 10);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.PageUp))
        {
            transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.PageDown))
        {
            transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
        }

        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartLooking();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopLooking();
        }
    }

    void OnDisable()
    {
        StopLooking();
    }

    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}