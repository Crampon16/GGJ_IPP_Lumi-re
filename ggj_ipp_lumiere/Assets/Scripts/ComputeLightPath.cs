using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

	public List<Vector3> light_path; //Each angle where the light will turn
	public bool recompute = true; //Whether the beam's trajectory is to be recomputed
	public GameObject light_source, player;


    // Start is called before the first frame update
    void Start()
    {
		//Find the light source

    }

    // Update is called once per frame
    void Update()
    {
        if (recompute)
		{
			recompute = false;
			light_path.Clear();
			light_path.Add(light_source.transform.position);

			float dir = light_source.dir;
			bool ray_absorbed = false;


			do
			{
				//Find everything on the trajectory of the ray
				RaycastHit[] hits;
				hits = Physics.RaycastAll(light_path[-1], dir, 100.0F);

				//Find the closest thing on the trajectory
				float min_mag = Mathf.Infinity;
				int min_index = -1;

				for (int i = 0; i < hits.Length; i++)
				{
					RaycastHit hit = hits[i];
					Transform tr = hit.transform;

					if ( (tr - light_path[-1]).Magnitude() < min_mag)
					{
						min_index = i;
						min_mag = (tr - light_path[-1]).Magnitude();
					}
				}

				//Stop the ray if it does not hit a mirror
				if(GetComponent<Mirror>(hits[min_index].collider.gameObject) == null)
					ray_absorbed = true;
				else //Make it bounce
				{
					//Add the new starting point
					light_path.Add(hits[min_index].collider.transform.position);

					//Find the new direction
					Mirror mir = GetComponent<Mirror>(hits[min_index].collider.gameObject);
					dir = Vector3.dot(dir, mir.d)*mir.d - Vector3.dot(dir, mir.n)*mir.n;
				}


			} while (!ray_absorbed)

			

		}
    }

	void 
}
