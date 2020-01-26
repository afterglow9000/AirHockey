using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private bool canMove;
    private Collider2D playerCollider;
    private Rigidbody2D rB;
    private bool wasJustClicked = true;

	private void Start ()
    {
        rB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
	}

	private void Update ()
    {
		if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if (playerCollider.OverlapPoint(mousePos))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                Vector2 clampedMousePos = new Vector2(
                    Mathf.Clamp(mousePos.x, 1f, 4f),
                    Mathf.Clamp(mousePos.y, -2f, 2f));
                rB.MovePosition(clampedMousePos);
            }
        }
        else
        {
            wasJustClicked = true;
        }
	}
}
