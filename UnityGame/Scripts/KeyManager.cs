using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyManager : MonoBehaviour
{
    //public Text m_KeyCountText;
    public GameObject Trigger1;
    public GameObject Key;

    [HideInInspector]
    public bool isKeyTaken;

   

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    void OnTriggerStay(Collider other)
    {
        if (!isKeyTaken)
        {
            Destroy(Key);
            isKeyTaken = true;
            
        }
        
    }

   
}
