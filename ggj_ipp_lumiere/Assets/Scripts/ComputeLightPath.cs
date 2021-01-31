using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

	public List<Vector3> light_path; //Each angle where the light will turn
	public bool recompute = true; //Whether the beam's trajectory is to be recomputed
	public Vector3 source_direction; //Direction of the first light beam


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (recompute)
		{
			recompute = false;
			light_path.Clear();
			light_path.Add(transform.position);

			Vector3 dir = source_direction;
			bool ray_absorbed = false;

			do
			{
				//Find everything on the trajectory of the ray
				RaycastHit[] hits;
				hits = Physics.RaycastAll(light_path[light_path.Count - 1], dir, 100.0F);

				//Find the closest thing on the trajectory
				float min_mag = Mathf.Infinity;
				int min_index = -1;

				for (int i = 0; i < hits.Length; i++)
				{
					RaycastHit hit = hits[i];
					Transform tr = hit.transform;

					if ( (tr.position - light_path[light_path.Count - 1]).magnitude < min_mag)
					{
						if (hit.collider.gameObject.GetComponent<Diamondo>() != null)
						{
							print("Yes");
							// if hit a diamondo
							// don't consider it as a hit
							// set isLight (in Animation Script) to True
						}
						else
						{
							min_index = i;
							min_mag = (tr.position - light_path[light_path.Count - 1]).magnitude;
						}
					}
				}

				//Stop the ray if it does not hit a mirror
				if(hits[min_index].collider.gameObject.GetComponent<Mirror>() == null)
					ray_absorbed = true;
				else //Make it bounce
				{
					//Add the new starting point
					light_path.Add(hits[min_index].collider.transform.position);

					//Find the new direction
					Mirror mir = hits[min_index].collider.gameObject.GetComponent<Mirror>();
					dir = Vector3.Dot(dir, mir.d)*mir.d - Vector3.Dot(dir, mir.n)*mir.n;
				}


				//Spawn the light ray

			} while (!ray_absorbed);
	

		}

		for( int i = 0; i < light_path.Count - 1; ++i )
			Debug.DrawRay(light_path[i], 
						light_path[i+1] - light_path[i], 
						Color.yellow);


    } 
}
