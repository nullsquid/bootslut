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
        EventManager.StartListening("greenHappy", IsGreenHappy);
        EventManager.StartListening("cumming", IsCumming);
        EventManager.StartListening("yellow", IsYellow);
        EventManager.StartListening("red", IsRed);
    }

    void OnDisable() {
        EventManager.StopListening("greenIdle", IsGreenIdle);
        EventManager.StopListening("greenHappy", IsGreenHappy);
        EventManager.StopListening("cumming", IsCumming);
        EventManager.StopListening("yellow", IsYellow);
        EventManager.StopListening("red", IsRed);
    }
	// Update is called once per frame
	
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
        sprite.sprite = faces[6];
        sprite.transform.localScale = new Vector3(Mathf.PingPong(Time.time, 1), Mathf.PingPong(Time.time, 1), transform.localScale.z);
    }

    void IsYellow() {
        sprite.sprite = faces[3];
        //frameCount = 0;
        if (timeBetweenFrames > 0)
        {
            timeBetweenFrames -= Time.deltaTime;
        }
        else {
            frameCount += 1;
            timeBetweenFrames = startTime;

        }
        if (frameCount % 2 == 0)
        {
            sprite.sprite = faces[3];
        }
        else {
            sprite.sprite = faces[4];
        }
    }

    void IsRed() {
        sprite.sprite = faces[5];
    }
    
}
