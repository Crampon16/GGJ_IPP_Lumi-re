using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamondo : MonoBehaviour
{
    Light crystalLight;
    LightSource lightSourceScript;
    float defaultIntensity = 2.5f;
    bool crystalHit;

    // Start is called before the first frame update
    void Start()
    {
        GameObject childrenLight = this.transform.GetChild(0).gameObject;
        crystalLight = childrenLight.GetComponent<Light>();
        crystalLight.intensity = defaultIntensity;
        crystalHit = false;

        //

        GameObject lightSource = GameObject.Find("Light source");
        lightSourceScript = lightSource.GetComponent<LightSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("IS CRYSTAL HIT? " + lightSourceScript.isCrystalHit);
    }

    /// <summary>
    /// Send message when hit by ray
    /// </summary>
    void HitByRay()
    {
        crystalHit = true;
        Debug.Log("I was hit by a Ray + crystalHit: " + crystalHit);
        crystalLight.intensity = 8f;

        // Still needs to come back to default intensity if the ray does not hit!!!!
    }
}
