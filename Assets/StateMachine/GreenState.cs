using UnityEngine;
using System.Collections;

public class GreenState : ISlutState {

    private readonly StatePatternSlut slut;
    public GreenState(StatePatternSlut statePatternSlut)
    {
        slut = statePatternSlut;
    }
	public void UpdateState () {
        WaitForInput();
        
	}

    public void ToGreenState()
    {
        Debug.Log("cannot transition to same state");
    }

    public void ToYellowState()
    {
        slut.currentState = slut.yellowState;
    }

    public void ToRedState()
    {
        slut.currentState = slut.redState;
    }

    private void WaitForInput()
    {
        Rest();
        slut.slutStats.pain -= Time.deltaTime * slut.slutStats.painDecay;
        if(slut.slutStats.pain > slut.painThresholdYellow)
        {
            //play "owch" animation and sound
            ToYellowState();
        }
        else if(slut.slutStats.pain > slut.painThresholdRed)
        {
            ToRedState();
        }
        if (slut.slutStats.arousal > slut.slutStats.arousalThreshold) {
            Orgasm();
        }
    }

    void Orgasm()
    {
        Debug.Log("Orgasm");

    }
    
    /*IEnumerator Rest()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            slut.slutStats.exhaustion -= 1;
            if(slut.slutStats.exhaustion <= 0)
            {
                slut.slutStats.exhaustion = 0;
            }
        }
    }*/

    void Rest()
    {
        //slut.painCurCooldown += Time.deltaTime;
        if (slut.slutStats.exhaustion > 0)
        {
            slut.slutStats.exhaustion -= Time.deltaTime ;
        }
        if(slut.slutStats.exhaustion <= 0)
        {
            slut.slutStats.exhaustion = 0;
        }
    }
}
