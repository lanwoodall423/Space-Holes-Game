using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CorvetteMovement : MonoBehaviour {

    Vector3 startPosition;

    public Transform startMarker;
    public Transform endMarker;
    Vector3 randomRotation;
    Vector3 initialPosition;
    Quaternion initialRotation;
    Quaternion endingRotation;

    int radius = 15;
    public float speed = 10.0f;
    public float rotateSpeed = 3;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        initialPosition = startMarker.position;
        startMarker.position = Random.insideUnitSphere * radius;
        startMarker.position += new Vector3(0, 4, 30);
        endMarker.position = startMarker.position;
        startMarker.position = initialPosition;

        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        passiveRotation();
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        if(this.transform.position == endMarker.position)
        {
            distCovered = 0;
            fracJourney = 0;
            PassiveMovement();
        }
        
        transform.rotation = Quaternion.Slerp(transform.rotation,endingRotation,Time.deltaTime * rotateSpeed);
        if(this.transform.rotation == endingRotation)
        {
            passiveRotation();
        }
    }
    void PassiveMovement()
    {
        endMarker.position = Random.insideUnitSphere * radius;
        endMarker.position += new Vector3(0, 4, 30);
        startMarker.position = this.transform.position;

        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void passiveRotation()
    {
        randomRotation = new Vector3(Random.Range(100, 130), Random.Range(-10, 10), Random.Range(130, 190));
        endingRotation = Quaternion.Euler(randomRotation);
    }
}
