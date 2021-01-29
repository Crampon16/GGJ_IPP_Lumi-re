using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables

    [Header("Movement Information")]
    public float InputX; // Range between -1 and 1 for horizontal axis (sides).
    public float InputZ; // Range between -1 and 1 for vertical axis (forward).

    [Header("Thresholds of movement")]
    public float Speed = 15f;

    public CharacterController _controller; // Contains controller and collider
    public Camera cam;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Getting components from Inspector.
        cam = Camera.main; // Gets automatically the main camera of the scene
        _controller = GetComponent<CharacterController>(); // Gets automatically the character controller associated to the player
    }

    // Update is called once per frame
    void Update()
    {
        // For Character controlling.
        InputMagnitude();
    }

    /// <summary>
    /// Method to calculate input vectors.
    /// </summary>
    void InputMagnitude()
    {
        // Calculate Input Vectors (key arrows)
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        // Uses the Character Controller API to move the player a Vector3
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
    }
}
