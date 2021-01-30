using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{

	public List<Vector3> light_path; //Each angle where the light will turn
	public Vector3 source_direction; //Direction of the first light beam
	public GameObject lightBeamPrefab;

    // Start is called before the first frame update
    void Start()
    {
		RecomputePath();
    }

    // Update is called once per frame
    void Update()
    {
        for ( int i = light_path.Count - 1; i > 0; --i )
			Debug.DrawLine(light_path[i], light_path[i-1], Color.yellow);
    } 


	void RecomputePath()
	{
		light_path.Clear();
		light_path.Add(transform.position);

		Vector3 dir = source_direction;
		bool ray_absorbed = false;


		while (!ray_absorbed)
		{
			//Find the closest thing on the trajectory
			Ray ray = new Ray(light_path[light_path.Count - 1], dir);
			RaycastHit hit;

			//If the ray hit
			if (Physics.Raycast(ray, out hit, 100))
			{
				//Spawn the beam of light
				Vector3 pos = (light_path[light_path.Count - 1] + hit.point)/2;
				Quaternion rot = Quaternion.FromToRotation(Vector3.forward, dir)
                                             * lightBeamPrefab.transform.rotation;
				Instantiate(lightBeamPrefab, pos, rot);

				//Add the new point
				light_path.Add(hit.point);

				//Stop the ray if it does not hit a mirror
				if (hit.collider.gameObject.GetComponent<Mirror>() == null)
					ray_absorbed = true;
				else //Or make it bounce
				{
					//Find the new direction
					Mirror mir = hit.collider.gameObject.GetComponent<Mirror>();
					dir = Vector3.Dot(dir, mir.d) * mir.d - Vector3.Dot(dir, mir.n) * mir.n;
				}
			}
			else
			{
				ray_absorbed = true;
				light_path.Add(light_path[light_path.Count - 1] + dir * 100);
			}
		}

		Debug.Log("Number of bounces: " + light_path.Count);
	}
}
