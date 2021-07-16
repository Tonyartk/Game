using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField]
    internal PlayerInputScript inputScript;

    [SerializeField]
    internal PlayerMovementScript movementScript;
    [SerializeField]
    internal PlayerJumpScript jumpScript;
    [SerializeField]
    internal PlayerGroundCheckScript groundCheckScript;
    //movement
    internal Rigidbody2D rb2d;
    [Header("Movements Varibales")]
    [SerializeField]
    internal float movementAceeleration;
    [SerializeField]
    internal float maxMoveSpeed;
    [SerializeField]
    internal float GroundLinearDrag; // diseleration of movement
    internal float horizontalDirection;
    public bool changingDirection => (rb2d.velocity.x > 0f && horizontalDirection < 0f) || (rb2d.velocity.x < 0f && horizontalDirection > 0f);

    //jump
    [Header("Jump Varibales")]
    [SerializeField]
    internal float jumpForce;
    [SerializeField]
    internal float fallMultipier;
    [SerializeField]
    internal float lowJumpMultiplier;
    [SerializeField]
    internal float airLinearDrag = 2.5f;
    [SerializeField]
    internal int extraJumps = 1;
    [SerializeField]
    internal int extraJumpsValues;
    public bool canJump => Input.GetButtonDown("Jump") && (isGrunded || extraJumpsValues > 0);


    //Zmienne do PlayerGroundCheck
    [Header("Ground Collider Veriables")]
    public LayerMask groundLayer;
    internal bool isGrunded;
    public float groundRadiusLenght;


    // Start is called before the first frame update
    void Start()
    {
        print("Main Player Scrript is Starting");
        rb2d = GetComponent<Rigidbody2D>();
    }
}
