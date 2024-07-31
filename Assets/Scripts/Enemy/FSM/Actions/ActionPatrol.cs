using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPatrol : FSMAction
{
  [Header("Config")]
  [SerializeField] private float speed;

  private Waypoint wayPoint;
  private int pointIndex; //as the index value of patrol point
  private Vector3 nextPosition; //

  private bool isPatrolForward;

  private void Awake()
  {
    wayPoint = GetComponent<Waypoint>();
  }

  private void Start()
  {
    isPatrolForward = true;
  }
  public override void Act()
  {
    FollowPath();
  }

  private void FollowPath()
  {
    transform.position = Vector3.MoveTowards(transform.position, GetCurrentPosition(), speed * Time.deltaTime);
    if (Vector3.Distance(transform.position, GetCurrentPosition()) < 0.1f)
    {
      UpdateNexPosition();
    }
  }

  private void UpdateNexPosition()
  {
    if (isPatrolForward)
    {
      pointIndex++;
      if (pointIndex >= wayPoint.Points.Length - 1)
      {
        isPatrolForward = false;
      }
    }
    else
    {
      pointIndex--;
      if (pointIndex <= 0)
        isPatrolForward = true;
    }

  }
  private Vector3 GetCurrentPosition()
  {
    // Debug.Log(pointIndex);
    return wayPoint.GetPosition(pointIndex);
  }
}
