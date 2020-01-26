using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puck : MonoBehaviour
{
    private int maxSpeed = 20;
    private Rigidbody2D rB;
    public Scores scores;
    public static bool wasGoal {get; set;}

    private void FixedUpdate()
    {
        rB.velocity = Vector2.ClampMagnitude(rB.velocity, maxSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!wasGoal)
        {
            if (other.tag == "BlueGoal")
            {
                scores.Increment(Scores.Score.RedScore);
                wasGoal = true;
                StartCoroutine(ResetPuck());
            }
            else if (other.tag == "RedGoal")
            {
                scores.Increment(Scores.Score.BlueScore);
                wasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        wasGoal = false;
        rB.velocity = rB.position = new Vector2(0, 0);
    }

    private void Start ()
    {
            rB = GetComponent<Rigidbody2D>();
            wasGoal = false;
    }
}
