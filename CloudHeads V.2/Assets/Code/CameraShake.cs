using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 startpos;
    float shakeVariance = 1;
    float shakeSpeed = 10;

    float timer;
    float timerEnd = .1f;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boolhub.screenShaking)
        {
            Shaking();
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startpos, Time.deltaTime * 4);
        }
    }

    void Shaking()
    {
        timer += Time.deltaTime;

        if (timer < timerEnd)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + Random.Range(-shakeVariance, shakeVariance), transform.position.y, transform.position.z + Random.Range(-shakeVariance, shakeVariance)), Time.deltaTime * shakeSpeed);
        }
        else
        {
            timer = 0;
            Boolhub.screenShaking = false;
        }
        
    }
}
