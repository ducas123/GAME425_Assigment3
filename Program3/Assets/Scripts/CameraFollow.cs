// ISTA 425 / INFO 525 Algorithms for Games
//
// Sample code file

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(-1.73f, 5.48f, -14.86f);
    public float springConstant = 1f;
    public float dampConstant = 1f;
    private Vector3 velocity;
    private Vector3 actualPosition;

    private void Start()
    {
        actualPosition = transform.position + offset;
    }
    private void FixedUpdate()
    {
        Vector3 idealPosition =
            player.transform.position - player.transform.forward * offset.x + player.transform.up * offset.y;
        Vector3 displacement = actualPosition - idealPosition;

        Vector3 springAccel = (-springConstant * displacement) - (dampConstant * velocity);
        velocity += springAccel * Time.deltaTime;
        actualPosition += velocity * Time.deltaTime;
        
        this.transform.position = actualPosition;
        transform.LookAt(player.transform.position);
        
    }
}
