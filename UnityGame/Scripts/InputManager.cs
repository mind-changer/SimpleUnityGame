using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public bool IsRunning;
    [HideInInspector]
    public bool IsJumping;

    [HideInInspector]
    public float Horizontal;
    [HideInInspector]
    public float Vertical;
    [HideInInspector]
    public float MouseX;
    [HideInInspector]
    public float MouseY;


    // Update is called once per frame
    private void FixedUpdate()
    {
        //Get Movement on X axis
        Horizontal = Input.GetAxisRaw("Horizontal");
        //Get Movement on Y axis
        Vertical = Input.GetAxisRaw("Vertical");

        //Spacebar press on Z axis when jumping
        IsJumping = Input.GetKeyDown(KeyCode.Space);
        IsRunning = Input.GetKey(KeyCode.LeftShift);

        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");
    }
}
