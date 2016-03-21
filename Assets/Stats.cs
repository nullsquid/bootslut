using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
    public float arousal;
    public float pain;
    public float exhaustion;
    public float idleArousalCap = 50;
    public float arousalThreshold = 100;
    public float painThreshold;
    public float painDecay = 2.5f;
    public float yellowCoolDown;

}
