using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGem : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    public bool isNear = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius)
        {
            isNear = true;
        }
    }

    public Transform nearThisGem()
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
