using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(BP_Test))]
public class requireComponent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {        
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<MeshCollider>().isTrigger = true;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
