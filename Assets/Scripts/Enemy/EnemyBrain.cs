using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
  //this class is responsible for Enemies' AI

  [SerializeField] private string initState; //patrol state
  [SerializeField] private FSMState[] states;
  public FSMState CurrentState { get; set; }

  private void Start()
  {
    ChangeState(initState);
  }

  private void Update()
  {
    CurrentState?.UpdateState(this);
  }

  public void ChangeState(string newStateID)
  {
    FSMState newState = GetFSMState(newStateID);
    if (newState != null)
    {
      CurrentState = newState;
    }
  }

  private FSMState GetFSMState(string stateID)
  {

    for (int i = 0; i < states.Length; i++)
    {
      if (states[i].stateID == stateID)
      {
        return states[i];
      }
    }
    return null;
  }
}