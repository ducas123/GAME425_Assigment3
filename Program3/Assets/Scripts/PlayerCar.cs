// ISTA 425 / INFO 525 Algorithms for Games
//
// Sample code file

using UnityEngine;

public class PlayerCar : Car
{
    public override void SetInputs()
    {
        steerInput = Input.GetAxis("Horizontal");
        moveInput = Input.GetAxis("Vertical");
        brakeInput = Input.GetKey(KeyCode.Space);
    }
}