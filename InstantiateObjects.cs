using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateObjects : MonoBehaviour
{
    [SerializeField] InputField widthField, lengthField;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject nest;
    float xsize, zsize;
    Ray myRay;
    RaycastHit hit;

    void InstantiateObject(RaycastHit hit)
    {
        if (widthField.text != "" && lengthField.text != "")
        {
            xsize = Int32.Parse(widthField.text);
            zsize = Int32.Parse(lengthField.text);
            cube.transform.localScale = new Vector3(xsize, 1, zsize);

            Instantiate(cube, hit.point, Quaternion.identity, nest.transform);
        }
        else Debug.Log("Null cube data");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Ground")
                {
                    myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
 
                    if(Physics.Raycast(myRay, out hit))
                        InstantiateObject(hit);
                }
            }
        } 
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray, out hitInfo))
            {
                myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
 
                if(Physics.Raycast(myRay, out hit))
                    if (hit.transform.gameObject.tag == "Block")
                        Destroy(hit.transform.gameObject);
            }
        }
    }
}
