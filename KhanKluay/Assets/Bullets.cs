using UnityEngine;
using System.Collections;
 
public class Bullet : MonoBehaviour {
public float speed = 6f;
public float SecondsUntilDestroy = 0.16f;
float startTime;
 
 void Start () {
   startTime = Time.time;
 }
 
 void Update () {
   transform.Translate(Vector2.right * speed * Time.deltaTime);
   if (Time.time - startTime >= SecondsUntilDestroy) {
     Destroy(this.gameObject);
   }
 }
}