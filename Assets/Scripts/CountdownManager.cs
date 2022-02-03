using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{
    public float startTime;
    public float timeRemaining;
    public Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            // round over
        }
        countdownText.text = timeRemaining.ToString("0");
    }
}
