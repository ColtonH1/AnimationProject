using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGem : MonoBehaviour
{
    public float lookRadius = 10f;

    public GameObject target;
    public bool isNear = false;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Gem");
        distance = Vector3.Distance(target.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);

        if(distance <= lookRadius)
        {
            isNear = true;
        }
        else
        {
            isNear = false;
        }
    }

    public GameObject nearThisGem()
    {
        return target;
    }
    public bool nearGem()
    {
        return isNear;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
