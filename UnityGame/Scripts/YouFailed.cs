using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouFailed : MonoBehaviour
{
    private bool isPlaying;
    public GameObject m_YouFailed;
    // Start is called before the first frame update
    void Start()
    {
        m_YouFailed.SetActive(false);
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
