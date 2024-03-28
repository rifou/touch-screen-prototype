using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;


public class stimuli : MonoBehaviour
{

    public string name;
    public bool correct;
    float trialStart = 0;

    private SerialController serialController;


void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();

        trialStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        isChosen(Input.mousePosition);
    }
    void OnTouchStart(Touch touch)
    {
        Vector2 touchPosition = touch.position;
        isChosen(touchPosition);
    }
    private void isChosen(Vector2 coord)
    {
        string timeStamp = System.DateTime.UtcNow.ToLocalTime().ToString();
        float latency = Time.time - trialStart;
        stimuli_manager.instance.chosen_Stimuli(timeStamp, latency, name, coord);
        if(correct)
        {
            serialController.SendSerialMessage("1");
        }
    }
}
