using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Vector3 n;
    public Vector3 d;

    //Initializes variables
    void Awake()
    {
        n = transform.rotation*Vector3.forward;
        d = transform.rotation*Vector3.right;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
