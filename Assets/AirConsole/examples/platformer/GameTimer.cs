using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text m_MyText;
    private double timer = 0.0;

    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* timer += Time.deltaTime;
        m_MyText.text  = "" + timer;*/

        //set timer UI
        secondsCount += Time.deltaTime;
        m_MyText.text = hourCount + ":" + minuteCount + ":" + (int)secondsCount;
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
}
