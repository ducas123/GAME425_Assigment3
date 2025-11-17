// ISTA 425 / INFO 525 Algorithms for Games
//
// Sample code file

using UnityEngine;

public class NPCCar : Car
{
    public override void SetInputs()
    {
        moveInput =  0f;
        steerInput = 0f;
        brakeInput = false;
    }
}
