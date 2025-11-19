// ISTA 425 / INFO 525 Algorithms for Games
//
// Sample code file

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NPCCar : Car
{
    public override void SetInputs()
    {
        moveInput =  0f;
        steerInput = 0f;
        brakeInput = false;
    }

    //Catmull-Rom set-up
    public float position;
    Vector3 b0;
    Vector3 b1;
    Vector3 b2;
    Vector3 b3;
    

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
