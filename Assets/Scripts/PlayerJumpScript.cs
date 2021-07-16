using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    [SerializeField]
    internal PlayerScript playerScript;

    public void Update()
    {
        if (playerScript.canJump) playerScript.jumpScript.Jump();
    }
    public void FixedUpdate()
    {
        playerScript.groundCheckScript.CheckCollision();
        if (playerScript.isGrunded)
        {
            playerScript.extraJumpsValues = playerScript.extraJumps;
            playerScript.movementScript.ApplyGroundLinerDrag();
        }
        else
        {
            ApplyAirLinerDrag();
            FalMultiplier();
        }
    }
    public void Jump()
    {
        if(!playerScript.isGrunded)
        {
            playerScript.extraJumpsValues--;
        }
        playerScript.rb2d.velocity = new Vector2(playerScript.rb2d.velocity.x, 0f);
        playerScript.rb2d.AddForce(Vector2.up * playerScript.jumpForce, ForceMode2D.Impulse);
    }
    public void ApplyAirLinerDrag()
    {
        playerScript.rb2d.drag = playerScript.airLinearDrag;
    }
    public void FalMultiplier()
    {
        if ( playerScript.rb2d.velocity.y < 0)
        {
            playerScript.rb2d.velocity += Vector2.up * Physics2D.gravity.y * (playerScript.fallMultipier - 1) * Time.deltaTime;
        }
        else if ( playerScript.rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerScript.rb2d.velocity += Vector2.up * Physics2D.gravity.y * (playerScript.lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        
        /*if (playerScript.rb2d.velocity.y < 0)
        {
            playerScript.rb2d.gravityScale = playerScript.fallMultipier;
        }
        else if ( playerScript.rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerScript.rb2d.gravityScale = playerScript.lowJumpMultiplier;
        }
        else
        {
            playerScript.rb2d.gravityScale = 1f;
        }*/
    }

}
