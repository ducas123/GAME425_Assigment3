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

    private void Start()
    {
        this.transform.rotation = player.transform.rotation;
        this.transform.position = player.transform.position + offset;
    }
    private void FixedUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}
