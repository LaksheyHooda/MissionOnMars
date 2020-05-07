using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Editable speed and jump force to allow you to perfect player movement.
    [SerializeField] float playerSpeed = 20;
    [SerializeField] float playerJumpForce = 20;

    private float previousY = 0;
    // Update is called once per frame
    void Update()
    {
        //Calls the input handler
        PlayerInputHandler();
        previousY = transform.position.y;
    }

    /// <summary>
    ///Handles Player Input and chages player velocity acourdingly.
    /// </summary>
    private void PlayerInputHandler()
    {
        if (Input.GetKey("w"))
            MovePlayerForward();
        else if (Input.GetKey("s"))
            MovePlayerBackward();

        if (Input.GetKeyDown(KeyCode.Space))
            PlayerJump();
    }

    private void PlayerJump()
    {
        if (previousY == transform.position.y)
        {
            transform.position += Vector3.up * playerJumpForce * Time.deltaTime;
        }
    }
    private void MovePlayerForward()
    {
        transform.position += new Vector3(playerSpeed * Mathf.Sin(transform.eulerAngles.y * (Mathf.PI / 180)) * Time.deltaTime, 0, playerSpeed * Mathf.Cos(transform.eulerAngles.y * (Mathf.PI / 180)) * Time.deltaTime);
    }

    private void MovePlayerBackward()
    {
        transform.position -= new Vector3(playerSpeed * Mathf.Sin(transform.eulerAngles.y * (Mathf.PI / 180)) * Time.deltaTime, 0, playerSpeed * Mathf.Cos(transform.eulerAngles.y * (Mathf.PI / 180)) * Time.deltaTime);
    }
}
