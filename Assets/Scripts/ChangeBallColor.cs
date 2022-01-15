using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChangeBallColor : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Camera[] cameraList = FindObjectsOfType<Camera>();

            foreach (Camera camera in cameraList)
            {
                if (camera.name == "Canvas Camera")
                {
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    
                    if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == gameObject)
                    {
                        PlayerPrefs.SetString(Constants.BallMaterial, hit.transform.name);
                    }
                }
        }

        }    
    }
}
