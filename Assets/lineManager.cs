using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineManager : MonoBehaviour
{
    public GameObject line_prefab;

    public line activeLine;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
                GameObject currentLine = Instantiate(line_prefab);
            currentLine.transform.position = mousePos;
                activeLine = currentLine.GetComponent<line>();

            

        }
        if(Input.GetMouseButtonUp(0))
        {
            if (activeLine != null)
            {
                activeLine = null;
            }
        }
        if (activeLine != null)
        {
            if (activeLine is line)
            {
                activeLine.UpdatePoints(mousePos);
            }
        }
    }


}
