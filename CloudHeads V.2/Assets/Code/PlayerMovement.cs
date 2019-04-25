using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    CharacterController mover;
    Vector3 input;
    float speed = 10;

    public int playerID = 0;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        mover = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();

        mover.Move(input * Time.deltaTime * speed);
    }

    void PlayerInputs()
    {
        input = new Vector3(player.GetAxis("Horizontal"),0, player.GetAxis("Vertical"));


    }
}
