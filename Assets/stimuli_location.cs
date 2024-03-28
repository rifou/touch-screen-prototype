using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stimuli_location : MonoBehaviour
{
    GameObject stimuli;
    public GameObject empty;
    private SerialController serialController;
    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator initialise_stimuli (GameObject go)
    {

        Destroy(stimuli);

        yield return new WaitForSeconds(0.85f);
        stimuli = Instantiate(go,this.transform);
        serialController.SendSerialMessage("0");


    }
  /*
    public void Update_Stimuli(GameObject go)
    {
        Destroy(stimuli);
        stimuli = Instantiate(go, this.transform);

    }*/
    public void clear()
    {
        Destroy (stimuli);
        stimuli = Instantiate(empty,this.transform);
    }
}
