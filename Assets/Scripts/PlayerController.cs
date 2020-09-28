using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camTransform;

    //CHECKTHIS DELETE
    //public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ClientSend.PlayerShoot(camTransform.forward);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ClientSend.PlayerThrowItem(camTransform.forward);
        }


        //CHECKTHIS DELETE
        if (Input.GetKeyDown(KeyCode.W))
        {
            //animator.SetInteger()
            GameManager.players[Client.instance.myId].SetState(State.rifleWalkingForward);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            GameManager.players[Client.instance.myId].SetState(State.rifleIdle);
        }
    }

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    private void SendInputToServer()
    {
        bool[] _inputs = new bool[]
        {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.Space)
        };

        

        ClientSend.PlayerMovement(_inputs);
    }
}
