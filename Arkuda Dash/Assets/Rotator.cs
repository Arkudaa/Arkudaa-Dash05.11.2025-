using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public new Renderer renderer;
    public PlayerController playerController;
    public float angle; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageRotation();
    }


    private void ManageRotation()
    {

        if (!playerController.isGrounded())
            PlayerNotGrounded();
        else
            PlayerGrounded();


    }

    public void PlayerNotGrounded()
    {
        // Meie sprite pöörleb
        renderer.transform.localEulerAngles += Vector3.forward * Time.deltaTime * angle;
    }


    public void PlayerGrounded()
    {
        // Meie sprite ei pöörle
    }



}
