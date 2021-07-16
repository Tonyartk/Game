using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheckScript : MonoBehaviour
{
    [SerializeField]
    internal PlayerScript playerScript;

    public void CheckCollision()
    {
        playerScript.isGrunded = Physics2D.Raycast(transform.position * playerScript.groundRadiusLenght,Vector2.down, playerScript.groundRadiusLenght, playerScript.groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * playerScript.groundRadiusLenght);
    }
}
/*private void OnTriggerStay2D(Collider2D collider)
{
    isGrounded = collider != null && (((1 << collider.gameObject.layer) & playerScript.PlatfromFromeLayerMask) != 0);
}
private void OnTriggerExit2D(Collider2D collision)
{
    isGrounded = false;
}*/
//To do zmiany zrobic na gizmoscie zeby nie wyciagac obiektów

