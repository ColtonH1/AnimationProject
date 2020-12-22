using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparx : MonoBehaviour
{
    public GameObject thePlayer;
    public float targetDistance;
    public float allowedDistance = 5;
    public GameObject theNPC;
    public float followSpeed;
    public RaycastHit shot;

    public FindGem findGem;
    public bool foundGem;

    // Update is called once per frame
    void Update()
    {
        FollowSpyro();
        if(findGem.nearGem())
        {
            foundGem = true;
        }
        else
        {
            foundGem = false;
        }
        if(foundGem)
        {
            transform.position = Vector3.MoveTowards(transform.position, findGem.nearThisGem().position, followSpeed * Time.deltaTime); // move to the gem
        }
    }

    private void FollowSpyro()
    {
        transform.LookAt(thePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if (targetDistance >= allowedDistance)
            {
                followSpeed = 0.1f;
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0;
            }
        }
    }
}
