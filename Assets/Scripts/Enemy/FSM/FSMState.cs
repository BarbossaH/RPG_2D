using System;
using UnityEditorInternal;

//for each stage it could be able to perform different actions and different transitions.
//for example, if the monster is in the attack state, it could have move and attack actions, and it also could have two transitions because of two actions.
[Serializable]
public class FSMState
{
  public string stateID; //define the name of the state
  public FSMAction[] Actions; //
  public FSMTransition[] Transitions;

  public void UpdateState(EnemyBrain enemyBrain)
  {
    ExecuteActions();
    ExecuteTransitions(enemyBrain);
  }
  private void ExecuteActions()
  {
    for (int i = 0; i < Actions.Length; i++)
    {
      Actions[i].Act();
    }
  }
  private void ExecuteTransitions(EnemyBrain enemyBrain)
  {
    if (Transitions == null || Transitions.Length <= 0) return;
    for (int i = 0; i < Transitions.Length; i++)
    {
      bool value = Transitions[i].Decision.Decide();
      if (value)
      {
        enemyBrain.ChangeState(Transitions[i].TrueState);
      }
      else
      {
        enemyBrain.ChangeState(Transitions[i].FalseState);
      }
    }
  }
}