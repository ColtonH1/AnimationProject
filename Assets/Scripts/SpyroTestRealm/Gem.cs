﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    bool hasTriggered, firstTime;
    public Transform playerT;
    Vector3 firstPos;
    float timer;

    private void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("Player") || other.CompareTag("Sparx")) && !hasTriggered)
        {
            hasTriggered = true;
            firstPos = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") || collision.collider.CompareTag("Sparx"))
        {
            hasTriggered = false;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hasTriggered)
        {
            if(timer > 1)
            {
                gameObject.SetActive(false);
            }

            timer += Time.deltaTime;
            var mid = (playerT.position + firstPos) / 2;
            mid = new Vector3(mid.x, mid.y + 1.5f, mid.z);

            var upper = firstPos + new Vector3(0, 2, 0);

            transform.position = CalculateCubicBazierPosition(firstPos, upper, mid, playerT.position, timer);
        }
    }

    Vector3 CalculateCubicBazierPosition(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        return (((1 - t) * (1 - t) * (1 - t)) * p0 + 3 * ((1 - t) * (1 - t)) * t * p1 + 3 * (1 - t) * t * t * p2 + t * t * t * p3);
    }

}
