using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OpenDoor()
    {
        Debug.Log("Opening Door");
        this.transform.Translate(Vector3.forward * 20f);

        // Play sound? Move progressivelly?
    }
}
