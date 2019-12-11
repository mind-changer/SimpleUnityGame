using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouMadeIt : MonoBehaviour
{
    private bool isPlaying;
    public GameObject m_YouMadeIt;
    // Start is called before the first frame update
    void Start()
    {
        m_YouMadeIt.SetActive(false);
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
