﻿#region Access
using UnityEngine;
using UnityEngine.AI;
using XavHelpTo;
#endregion
/// <summary>
/// Controller of the movement
/// </summary>
public class MovementController : MonoBehaviour
{
    #region Variables
    //private CharacterController player;
    private Vector3 movement = new Vector3();
    #endregion
    #region Events
    #endregion
    #region Methods
    /// <summary>
    /// check if it can move
    /// </summary>
    private bool CanMove => enabled && !Time.timeScale.Equals(0);

    /// <summary>
    /// Move the player in X and Z based on the orientation of the transform in Z axis (forward)
    /// </summary>
    public void Move(CharacterController player, float speed, float x, float y = 0, float z = 0)
    {
        if (!CanMove) return; //🛡

        movement.Set(x, y, z);

        // orientates the vector of movement
        movement = player.transform.rotation * movement;

        //normalize the values to max 1.
        movement = movement.normalized;

        player.Move(movement * speed * Time.deltaTime);
    }
    /// <summary>
    /// Do the movement for a agent
    /// TODO
    /// </summary>
    public void Move(NavMeshAgent agent, float speed, float x, float y = 0, float z = 0)
    {
        if (!CanMove) return; //🛡


    }
    #endregion
}