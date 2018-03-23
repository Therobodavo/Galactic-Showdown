using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {

    //Animation class

    //attributes
    SpriteRenderer Rend; //render
    public Sprite[] Number; // holds each sprite
    public Sprite[] noNumber; // holds each sprite
 
    Sprite[] animations; // holds each sprite
    public float Timer; // timer to change sprite
    public int AniTime; //specfic timer that controls frames
    public float increase;

    // Use this for initialization
    void Start()
    {

        Timer = 0;
        AniTime = 0;
        Rend = (SpriteRenderer)GetComponent("SpriteRenderer");
    }

    // Update is called once per frame
    void Update()
    {
        
        Timer += increase;
        animations = Number;
        

        AniTime = (int)Mathf.Round(Timer);

        if (AniTime >= animations.Length)
        {
            Timer = 0;
        }

        if (AniTime < animations.Length)
        {
            Rend.sprite = animations[AniTime];
        }
    }
}
