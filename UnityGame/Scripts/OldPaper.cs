﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPaper : MonoBehaviour
{
    public GameObject m_OldPaper;

    // Start is called before the first frame update
    void Start()
    {
        m_OldPaper.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_OldPaper.SetActive(false);
        }
    }
}
