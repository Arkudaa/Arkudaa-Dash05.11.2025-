using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMover : MonoBehaviour
{
    public Transform bg1;
    public Transform bg2;
    public Camera cam;
    public float width;
    void Update()
    {
        if (cam != null)
        {
            if (cam.transform.position.x - bg1.position.x > width)
            {
                bg1.position = new Vector3(bg2.position.x + width, bg1.position.y, bg1.position.z);
            }


            if (cam.transform.position.x - bg2.position.x > width)
            {
                bg2.position = new Vector3(bg1.position.x + width, bg2.position.y, bg2.position.z);
            }
        }

        




    }
}
