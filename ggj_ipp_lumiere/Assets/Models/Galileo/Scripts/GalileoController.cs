using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GalileoController : MonoBehaviour
{
    #region Variables

    [Header("Movement Information")]
    public bool activateRotation;

    [Header("Movement Information")]
    public float InputX; // Range between -1 and 1 for horizontal axis (sides).
    public float InputZ; // Range between -1 and 1 for vertical axis (forward).
    public Vector3 dir;
    public float angle;

    [Header("Thresholds of movement")]
    public float Speed = 15f;

    [Header("Light that turns")]
    public Light directionalLight;

    public CharacterController _controller; // Contains controller and collider
    public Camera cam; // Camera
    public Animator _anim;

    private float animationSpeed;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Getting components from Inspector.
        cam = Camera.main; // Gets automatically the main camera of the scene
        _controller = GetComponent<CharacterController>(); // Gets automatically the character controller associated to the player
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // For Character controlling.
        InputMagnitude();

        // Rotate towards mouse
        if (activateRotation)
            faceMouse();
    }

    void faceMouse()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); // Get world mouse position and set it with respect to character
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; // Get euler angle (being 0 the horizontal axis)
        //transform.rotation = Quaternion.AngleAxis(-angle + 90f, Vector3.up); // Rotate character wrt y-axis (had to set that offset to match the rotation of the character)
        directionalLight.transform.rotation = Quaternion.AngleAxis(-angle + 90f, Vector3.up);
    }

    /// <summary>
    /// Method to calculate input vectors.
    /// </summary>
    void InputMagnitude()
    {
        // Calculate Input Vectors (key arrows)
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        // Set Floats into the animator equal to the inputs.
        _anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime);
        _anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime);

        // Uses the Character Controller API to move the player a Vector3
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
        
        this.transform.rotation = Quaternion.LookRotation(move);

        animationSpeed = new Vector2(InputX, InputZ).sqrMagnitude;
        _anim.SetFloat("InputMagnitude", animationSpeed, 0.0f, Time.deltaTime);

    }
}
