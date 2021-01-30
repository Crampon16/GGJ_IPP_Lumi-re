﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    /// <summary>
    /// Here we can detect when the character triggers certain object. We can detect which object is and execute anything based on it (go to next level, run an audio clip, etc...)
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Name: " + other.gameObject.name);

        if (other.tag == "Goal")
        {
            Debug.Log("You reached the goal! - Going to next level");

            // Code for going to next level
            // ==========

            // ==========
        }

        // We can put here also actions when we hit an enemy (if tag == "Enemy"...)
    }
}
