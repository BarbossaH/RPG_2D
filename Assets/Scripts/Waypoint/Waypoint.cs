using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Vector3[] points;// to store the points in the path.
    public Vector3[] Points => points;
    public Vector3 EntityPosition { get; set; } // to store the red circle current position
    private bool gameStarted;
    private void Start()
    {
        EntityPosition = transform.position;
        gameStarted = true;
    }

    public Vector3 GetPosition(int pointIndex)
    {
        return EntityPosition + points[pointIndex];
    }

    //this method is called when I check the scene vew, not the game view.
    private void OnDrawGizmos()
    {
        //if we are not in play mode and transform's position doesn't change
        if (!gameStarted && transform.hasChanged)
        {
            EntityPosition = transform.position;
        }
    }
}
