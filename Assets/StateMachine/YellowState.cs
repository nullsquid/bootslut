using UnityEngine;
using System.Collections;

public class YellowState : ISlutState {
    private float curTimer;
    private readonly StatePatternSlut slut;

    public YellowState(StatePatternSlut statePatternSlut)
    {
        slut = statePatternSlut;
    }
    // Use this for initialization
    public void UpdateState()
    {
        WaitForInput();
    }

    public void ToGreenState()
    {
        slut.painCurCooldown = 0.0f;
        slut.currentState = slut.greenState;
    }

    public void ToYellowState()
    {

    }

    public void ToRedState()
    {
        slut.currentState = slut.redState;
        slut.painCurCooldown = 0.0f;
    }
    public void WaitForInput()
    {
        StartCooldown();
        //StartCoroutine(PainCooldown());
        if(slut.slutStats.pain > slut.painThresholdRed)
        {
            //StopCooldown();
            //slut.StopAllCoroutines();
            ToRedState();

        }
    }
    public void StartCooldown()
    {
        //slut.isCoolingDown = true;
        
        slut.painCurCooldown += Time.deltaTime;
        if (slut.slutStats.pain > 0)
        {
            slut.slutStats.pain -= Time.deltaTime * slut.slutStats.painDecay;
        }
        if(slut.painCurCooldown > slut.painCooldownTime)
        {
            ToGreenState();
        }
    }
}
