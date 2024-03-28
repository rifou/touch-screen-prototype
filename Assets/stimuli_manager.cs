using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class stimuli_manager : MonoBehaviour
{
    public static stimuli_manager instance;
    public List<GameObject> stimuli = new List<GameObject>();
    public List<stimuli_location> locations = new List<stimuli_location>();
    List<string> choices = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Reset_stimuli();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print_data();
        }
    }

    public void Reset_stimuli()
    {
        int locations_count = locations.Count;
        List<stimuli_location> leftover_locations = new List<stimuli_location> ();
        for (int i = 0; i < locations_count; i++)
        {

            leftover_locations.Add(locations[i]);
        }

        for (int i = 0;i < locations_count; i++)
        {
            UnityEngine.Debug.Log("here");
            int random_location = Random.Range(0, leftover_locations.Count);
            stimuli_location current_location = leftover_locations[random_location];
            StartCoroutine(current_location.initialise_stimuli(stimuli[i]));
            leftover_locations.Remove(leftover_locations[random_location]);
            Debug.Log(i);

        }
    }
    public void chosen_Stimuli(string timeStamp, float latency, string stimulus, Vector2 coord)
    {
        string choice = timeStamp + ";" + latency.ToString() + ";" + stimulus+";"+coord.ToString();
        choices.Add(choice); 
        Reset_stimuli();

    }
    void print_data()
    {
        string filePath = Application.dataPath + "/Session Data";
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        string date = System.DateTime.UtcNow.ToLocalTime().ToString("yyyyMMdd_HHmmss");
        string path = filePath+"/Touch_screen_data"+date+".txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Time;latency;stimulus;coordinates");
        for(int i = 0; i < choices.Count; i++)
        {
            writer.WriteLine(choices[i]);
        }
        writer.Close();


    }
}
