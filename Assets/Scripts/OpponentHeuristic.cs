using UnityEngine;


public class OpponentHeuristic : MonoBehaviour
{
    private bool isFirstTimeInOpponentsHalf = true;
    private float maxMovementSpeed = 20;
    private float offsetXFromTarget;
    public Rigidbody2D puck;
    private Rigidbody2D rb;
    private Vector2 startingPosition;
    private Vector2 targetPosition;


    private void FixedUpdate ()
    {
        if (!Puck.wasGoal)
        {
            float movementSpeed;

            if (puck.position.x > 1)
            {
                if (isFirstTimeInOpponentsHalf)
                {
                    isFirstTimeInOpponentsHalf = false;
                    offsetXFromTarget = Random.Range(-1f, 1f);
                }

                movementSpeed = maxMovementSpeed * Random.Range(0.1f, 0.3f);
                targetPosition = new Vector2(
                    Mathf.Clamp(puck.position.x + offsetXFromTarget, -4f, -1f),
                    startingPosition.y);
            }
            else
            {
                isFirstTimeInOpponentsHalf = true;
                movementSpeed = Random.Range(maxMovementSpeed * 0.4f, maxMovementSpeed);
                targetPosition = new Vector2(
                    Mathf.Clamp(puck.position.x, -4f, -1f),
                    Mathf.Clamp(puck.position.y, -2f, 2f));
            }

            rb.MovePosition(
                Vector2.MoveTowards(
                    rb.position,
                    targetPosition,
                    movementSpeed * Time.fixedDeltaTime));
        }
    }

    private void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = rb.position;
    }
}
