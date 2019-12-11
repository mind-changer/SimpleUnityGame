using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyLabel : MonoBehaviour
{

    private Text m_KeyLabel;
    private KeyManager m_KeyManager;
    private int KeyCount =0;
    // Start is called before the first frame update
    void Start()
    {
        m_KeyLabel = GetComponent<Text>();
        m_KeyManager = GetComponent<KeyManager>();
        m_KeyLabel.text = "0/4";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_KeyManager.isKeyTaken == true)
        {
            KeyCount += 1;
            m_KeyLabel.text = "KeyCount:" + KeyCount.ToString() +"/4";
            
        }
    }
}
