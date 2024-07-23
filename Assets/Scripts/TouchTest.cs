using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchTest : MonoBehaviour
{
    public ArtDisplay artDisplay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.tag);

                if (hit.transform.tag == "DrawTrigger")
                {
                    if (hit.transform.gameObject.name == "SunTrigger")
                    {
                        artDisplay.ShowSun(); 
                    }
                    
                    if (hit.transform.gameObject.name == "LightTrigger")
                    {
                        artDisplay.ShowLight();  
                    }
                    
                    if (hit.transform.gameObject.name == "BlueTearTrigger")
                    {
                        artDisplay.ShowBlueTear();
                    }
                }

                // if (hit.transform.tag == "frogger")
                // {
                //     Vector3 pos = hit.point;
                //     pos.z += 0.25f;
                //     pos.y += 0.25f;
                //     Instantiate(froggerVid, pos, transform.rotation);
                // }
            }
        }
    }
}