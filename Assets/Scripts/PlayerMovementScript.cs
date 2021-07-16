using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    internal PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        print("PlayerMovementScript Starting");
    }
    public void Update()
    {
        MoveCharacter();
        ApplyGroundLinerDrag();
    }
    public void MoveCharacter()
    {
        playerScript.rb2d.AddForce(new Vector2(playerScript.horizontalDirection, 0f) * playerScript.movementAceeleration);

        if(Mathf.Abs(playerScript.rb2d.velocity.x) > playerScript.maxMoveSpeed)
        playerScript.rb2d.velocity = new Vector2(Mathf.Sign(playerScript.rb2d.velocity.x) * playerScript.maxMoveSpeed, playerScript.rb2d.velocity.y);
    }
    public void ApplyGroundLinerDrag()
    {
        if (Mathf.Abs(playerScript.horizontalDirection) < 0.4f || playerScript.changingDirection)
        {
            playerScript.rb2d.drag = playerScript.GroundLinearDrag; // drag is to slow down the object
        }
        else
        {
            playerScript.rb2d.drag = 0f;
        }
    }

}
