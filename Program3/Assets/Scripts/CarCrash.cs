using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    public PlayerCar playerCar;
    
    public float minorDamageReq;
    public float moderateDamageReq;
    public float severeDamageReq;
    public Rigidbody rb;

    public AudioSource minorSFX;
    public AudioSource moderateSFX;
    public AudioSource severeSFX;
    
    private Vector3 velocity;
    private Vector3 lastVelocity;

    public float crashTreshhold;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
        lastVelocity = velocity;
    }
    
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = rb.velocity;
        if (lastVelocity.magnitude >= velocity.magnitude + crashTreshhold)
        {
            print("CRASH!");
            float impact = rb.mass * lastVelocity.magnitude;
            print(impact);
            if (impact >= severeDamageReq)
            {
                print("Major Impact");
                severeSFX.Play();
                playerCar.enabled = false;
            }
            else if(impact >= moderateDamageReq)
            {
                print("Moderate Impact");
                moderateSFX.Play();
            }
            else if (impact >= minorDamageReq)
            {
                print("Minor Impact");
                minorSFX.Play();
            }
        }
        //print(velocity.magnitude);
        lastVelocity = velocity;
    }
}
