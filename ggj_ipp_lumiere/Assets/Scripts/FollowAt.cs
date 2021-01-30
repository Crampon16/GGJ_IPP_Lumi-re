using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAt : MonoBehaviour
{
    [Header("Camera Information")]
    public GameObject followAt;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = followAt.transform.position + Vector3.up * yOffset;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = followAt.transform.position + Vector3.up * yOffset;   
    }
}
