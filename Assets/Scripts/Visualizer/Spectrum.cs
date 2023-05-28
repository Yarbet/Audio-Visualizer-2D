using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    public int numOfBars;
    public GameObject bar;
    public GameObject[] bars;
    
    void Start()
    {
        float posX = 0;
        for (int i = 0; i < numOfBars; i++)
        {
            Instantiate(bar, new Vector3(posX, 0, 0), Quaternion.identity);
            posX += 0.3f;
        }

        bars = GameObject.FindGameObjectsWithTag("Bar");
    }

    void Update()
    {
        float[] spectrum = new float[1024];
        AudioListener.GetOutputData(spectrum, 0);
        for (int i = 0; i < numOfBars; i++)
        {
            Vector3 prevScale = bars[i].transform.localScale;
            prevScale.y = spectrum[i] * 50;
            bars[i].transform.localScale = prevScale;
        }
    }
}
