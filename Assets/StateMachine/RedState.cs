using UnityEngine;
using System.Collections;

public class RedState : ISlutState {

    private readonly StatePatternSlut slut;

    public RedState(StatePatternSlut statePatternSlut)
    {
        slut = statePatternSlut;
    }
    public void UpdateState()
    {
        EventManager.TriggerEvent("red");
    }

    public void ToGreenState()
    {

    }

    public void ToYellowState()
    {

    }

    public void ToRedState()
    {

    }

    
}
