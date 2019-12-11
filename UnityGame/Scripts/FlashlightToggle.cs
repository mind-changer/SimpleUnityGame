using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
  
    [SerializeField]
    private AudioClip m_ClickSound;

    


    public Light m_Flashlight;
    private AudioSource m_Sound; 


    private void Awake()
    {
        m_Sound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       if(Input.GetMouseButtonDown(0))
        {
            m_Flashlight.enabled = !m_Flashlight.enabled;
            PlayClickSound();
        }

    }

    private void PlayClickSound()
    {
        m_Sound.clip = m_ClickSound;
        m_Sound.PlayOneShot(m_ClickSound);
    }
}
