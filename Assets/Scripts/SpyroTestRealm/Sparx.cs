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
    public RaycastHit shot; //what the raycast shoots at

    //public FindGem findGem;
    //public bool foundGem;
    //GameObject thisGem;
    //bool atGem = false;

    // Update is called once per frame
    void Update()
    {
        /*atGem = findGem.nearGem();
        if (atGem)
        {
            atGem = true;
            followSpeed = 0.1f;
            thisGem = findGem.nearThisGem();
            transform.Translate(Vector3.MoveTowards(transform.position, thisGem.transform.position, findGem.lookRadius) * followSpeed * Time.deltaTime);
            //transform.position.Set(thisGem.transform.position.x, thisGem.transform.position.y, thisGem.transform.position.z);// = Vector3.MoveTowards(transform.position, thisGem.transform.position, followSpeed * Time.deltaTime); // move to the gem
            Debug.Log("Found Gem " + thisGem + " Distance: " + findGem.lookRadius);
            
        }
        else*/
        FollowSpyro();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gem")
            atGem = false;
    }*/

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
