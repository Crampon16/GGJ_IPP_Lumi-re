using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    #region Variables

    [Header("Options")]
    public bool resetLight;

    [Header("Components")]
    public Light pointLight;
    public Light directionalLight;

    [Header("Properties")]
    public float pointMaxIntensity = 1f;
    public float directionalMaxIntensity = 2f;
    public float currentPointIntensity;
    public float currentDirectionalIntensity;
    [Range(0f, 0.1f)] public float fadeVel = 0.05f;
    public float deathLimit = 0.01f;

    [SerializeField] AudioClip audioDeath;
    SceneLoader sceneLoader;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Save initial intensities 
        currentPointIntensity = pointLight.intensity;
        currentDirectionalIntensity = directionalLight.intensity;

        // Set them to max initially
        currentPointIntensity = pointMaxIntensity;
        currentDirectionalIntensity = directionalMaxIntensity;

        // Need it to start menu when we die
        sceneLoader = FindObjectOfType<SceneLoader>();

    }

    // Update is called once per frame
    void Update()
    {
        reduceLife();
    }

    private void reduceLife()
    {
        if (resetLight)
        {
            pointLight.intensity = pointMaxIntensity;
            directionalLight.intensity = directionalMaxIntensity;
        }
        else
        {
            fadeLights();
        }
    }

    private void fadeLights()
    {
        currentPointIntensity = pointLight.intensity;
        currentDirectionalIntensity = directionalLight.intensity;

        // Reduce intensity
        float targetIntensity = 0f;
        float pointDelta = targetIntensity - currentPointIntensity;
        float directionDelta = targetIntensity - currentDirectionalIntensity;

        pointDelta *= Time.deltaTime * fadeVel;
        directionDelta *= Time.deltaTime * fadeVel;

        currentPointIntensity += pointDelta;
        currentDirectionalIntensity += directionDelta;

        pointLight.intensity = currentPointIntensity;
        directionalLight.intensity = currentDirectionalIntensity;

        // If any of the lights gets lower than certain threshold
        if (pointLight.intensity < deathLimit || directionalLight.intensity < deathLimit)
        {
            //Debug.Log("Died!");

            // Lights out
            pointLight.intensity = 0f;
            directionalLight.intensity = 0f;

            // TODO: DIE EVENT
            // ===============
            //

            // Play some clip and load start/game over scene with some delay
            AudioSource.PlayClipAtPoint(audioDeath, Camera.main.transform.position);
            Invoke("loadGameOver", 2f);

            // ===============
        }
    }

    public void loadGameOver()
    {
        Debug.Log("...now!");
        sceneLoader.LoadStartScene();
    }
}
