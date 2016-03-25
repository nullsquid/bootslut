using UnityEngine;
using System.Collections;

public class StatePatternSlut : MonoBehaviour {
    public float painCurCooldown;
    public float painCooldownTime;
    public bool isCoolingDown;
    //yellow should be not very much under red, forcing the player to maybe stop altogether until
    //they hit green again
    public float painThresholdYellow;
    public float painThresholdRed;
    public float pleasureThreshold;
    [HideInInspector] public Stats slutStats;
    [HideInInspector] public ISlutState currentState;
    [HideInInspector] public GreenState greenState;
    [HideInInspector] public YellowState yellowState;
    [HideInInspector] public RedState redState;

    void Awake()
    {
        greenState = new GreenState(this);
        yellowState = new YellowState(this);
        redState = new RedState(this);
        slutStats = GameObject.Find("Slut").GetComponent<Stats>();
    }
	// Use this for initialization
	void Start () {
        currentState = greenState;
	}
	
	// Update is called once per frame
	void Update () {
        currentState.UpdateState();
        Debug.Log(currentState);
        if(slutStats.pain < 0)
        {
            slutStats.pain = 0;
        }
        
	}

    
}
