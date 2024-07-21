using System;

[Serializable]
public class FSMTransition
{
  public FSMDecision Decision; //player in range of attack -> return true or false
  public string TrueState; //current state transitions to attack state
  public string FalseState; //current state transitions to patrol state
}