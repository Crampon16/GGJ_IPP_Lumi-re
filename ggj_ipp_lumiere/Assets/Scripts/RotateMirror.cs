using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMirror : MonoBehaviour
{

public float interact_range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Find the closest thing on the trajectory
			Ray ray = new Ray(transform.position + Vector3.up, transform.rotation*Vector3.forward);
			RaycastHit hit;
            
			//If the ray hit
			if (Physics.Raycast(ray, out hit, interact_range))
            {
                Debug.DrawLine(transform.position, hit.point);

                //And if it hit a mirror
                Mirror mir = hit.collider.gameObject.GetComponent<Mirror>();
                if (mir != null)
                    mir.Rotate();
            }
        }
    }
}
