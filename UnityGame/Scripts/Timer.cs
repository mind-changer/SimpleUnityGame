using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject YouFailedIt;

    private Text m_TimeLabel;
    public float m_StartTime;
    private float time;
    
    // Start is called before the first frame update
    void Start()
    {
        
        m_TimeLabel = GetComponent<Text>();
        time = m_StartTime;
         
    }

  
    void FixedUpdate()
    {
        time -= Time.deltaTime;

        float minutes = time / 60;
        float seconds = time % 60;
        //var fraction = (time * 100) % 100;

        if(seconds >= 0)
        {
            //m_TimeLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction); 
            m_TimeLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds); ;
        }
        

        if (seconds < 0) {

            Debug.Log("Game Over");
            YouFailedIt.SetActive(true);
            Time.timeScale = 0f;
            //WaitForSeconds()
            

        }
        
       
    }
    
}
