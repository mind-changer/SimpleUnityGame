using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraHandler : MonoBehaviour
{
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    [SerializeField]
    private float m_MouseSensitivity = 1.5f;


    private float m_MouseX;
    private float m_MouseY;

    private InputManager m_Input;

    private void Awake()
    {

        //To hide the cursor in Game Window
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        m_Input = GetComponentInParent<InputManager>();
    }

    private void LateUpdate()
    {
        m_MouseX +=  m_Input.MouseX * m_MouseSensitivity;
        m_MouseY -=  m_Input.MouseY * m_MouseSensitivity;

        // includes rotation across x,y,z axis
        Quaternion cameraRotation = Quaternion.Euler(m_MouseY, 0f, 0f);
        Quaternion playerRotation = Quaternion.Euler(0f, m_MouseX, 0f);

        //renders rotation of entity and parent entity respectively
        transform.localRotation = cameraRotation;
        transform.parent.localRotation = playerRotation;
    }

   
}
