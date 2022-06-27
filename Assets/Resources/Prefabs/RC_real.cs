using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(IA_Test))]
public class RC_real : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Furniture";
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
