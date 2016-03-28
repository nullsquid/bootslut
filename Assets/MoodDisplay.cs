using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MoodDisplay : MonoBehaviour {
    public List<Sprite> faces = new List<Sprite>();
    SpriteRenderer sprite;
    public float timeBetweenFrames;
    public float startTime;
    public int frameCount;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        timeBetweenFrames = startTime;
        //sprite.sprite = faces[0];
        
	}
	void OnEnable() {
        EventManager.StartListening("greenIdle", IsGreenIdle);
    }

    void OnDisable() {
        EventManager.StopListening("greenIdle", IsGreenIdle);
    }
	// Update is called once per frame
	void Update () {
	    
	}
    void IsGreenIdle() {
        sprite.sprite = faces[0];
        //frameCount = 0;
        if(timeBetweenFrames > 0) {
            timeBetweenFrames -= Time.deltaTime;
        }
        else {
            frameCount += 1;
            timeBetweenFrames = startTime;
            
        }
        if (frameCount % 2 == 0) {
            sprite.sprite = faces[0];
        }
        else {
            sprite.sprite = faces[1];
        }
    }
    void IsGreenHappy() {

    }
    void IsCumming() {

    }

    void IsYellow() {

    }

    void IsRed() {

    }
}
