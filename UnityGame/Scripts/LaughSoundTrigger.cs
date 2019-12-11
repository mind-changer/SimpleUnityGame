using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughSoundTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_LaughSound;

    private AudioSource m_TriggerAudio;
    private bool alreadyPlayed;
    private Vector3 pos = new Vector3(173.31f, 0.66f, 185.21f);


    // Start is called before the first frame update
    void Start()
    {
        m_TriggerAudio = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEntry(Collider other)
    {
        //Debug.Log("Entered");
        PlayAudio();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Entered");
        PlayAudio();
    }



    private void PlayAudio()
    {
        m_TriggerAudio.clip = m_LaughSound;

        if (!alreadyPlayed)
        {
            //AudioSource.PlayClipAtPoint(m_LaughSound, transform.position, 1.0f);
            m_TriggerAudio.PlayOneShot(m_LaughSound);
            alreadyPlayed = true;
        }
    }
}
