using UnityEngine;
using System.Collections;
 
public class enime : MonoBehaviour {
    public float walkSpeed = 1.0f;
    public float wallLeft = 0.5f;
    public float wallRight = 0.5f;
    public float walkingDirection = 0.5f;
    Vector3 walkAmount;
    void Update () {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
         if (walkingDirection > 0.0f && transform.position.x >= wallRight)
             walkingDirection = -1.0f;
         else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
             walkingDirection = 1.0f;
        transform.Translate(walkAmount);
    }
}