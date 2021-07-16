using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    [SerializeField]
    internal PlayerScript playerScript;

    void Start()
    {
        print("PlayerInputScript Starting");
    }

    void Update()
    {
        playerScript.horizontalDirection = GetInput().x;
        if (Input.GetButtonDown("Jump") && playerScript.isGrunded) playerScript.jumpScript.Jump();
    }
    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
