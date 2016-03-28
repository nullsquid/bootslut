using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SlutAnimation : MonoBehaviour {
    public List<AnimationClip> animations = new List<AnimationClip>();
    public Animation anim;
	// Use this for initialization
	void Start () {
        //animations[0].legacy = true;
        //this.animations[0].Play();
        anim = GetComponent<Animation>();
        //this.animation.Play()
        
        //anim.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
