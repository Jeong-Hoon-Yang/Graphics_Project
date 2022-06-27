using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnOff_Classic : MonoBehaviour
{

    private Light theLight;
    private GameObject target;
    public GameObject lamp1;
    public GameObject lamp2;
    
    private void Start()
    {
        theLight = GetComponent<Light>();
        
    }

    // Update is called once pe r frame
    private void Update()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때의 처리
        if(Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭
        {
    
            
            target = GetClickedObject();
    
            if(target.Equals(gameObject)) 
            {
                if(theLight.enabled == true)
                {
                    lamp1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                    lamp2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                    theLight.enabled = false; 
                }
        
                else 
                {
                    lamp1.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
                    lamp2.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
                    theLight.enabled = true;
                    
                }
            }
            
        }
    }
    private GameObject GetClickedObject() //오브젝트를 터치했는가
    {
        RaycastHit hit;
        GameObject target = null;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}