using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speedStart;
    public float increasePerSecond;
    private float secondsElapsed = 0;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * (increasePerSecond * secondsElapsed + speedStart));
        secondsElapsed += Time.deltaTime;
    }
}
