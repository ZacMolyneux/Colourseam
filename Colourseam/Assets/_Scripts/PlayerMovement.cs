using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public int player;
    public float movementSpeed;

    Rigidbody2D Rb;

    float thumbstickDeadZone = 0.2f;
    public float VelocityClamp = 5;

    //for rotating player
    private Vector3 lookDirection;
    public float currentTurnSpeed;
    


    void Start ()
    {
        Rb = GetComponent<Rigidbody2D>();
	}
	

	void Update ()
    {
        ThumbstickMovement();
        Rotate();
    }

    void ThumbstickMovement()
    {
        //move left or right
        if (Controller.state[player].ThumbSticks.Left.X > thumbstickDeadZone)
        {
            if (Rb.velocity.x < VelocityClamp)
            {
                Rb.AddForce(Vector2.right * movementSpeed * Time.deltaTime);
            }
        }
        else if (Controller.state[player].ThumbSticks.Left.X < -thumbstickDeadZone)
        {
            if (Rb.velocity.x > -VelocityClamp)
            {
                Rb.AddForce(Vector2.left * movementSpeed * Time.deltaTime);
            }
        }

        //move up or down
        if (Controller.state[player].ThumbSticks.Left.Y > thumbstickDeadZone)
        {
            if (Rb.velocity.y < VelocityClamp)
            {
                Rb.AddForce(Vector2.up * movementSpeed * Time.deltaTime);
            }
        }
        else if (Controller.state[player].ThumbSticks.Left.Y < -thumbstickDeadZone)
        {
            if (Rb.velocity.y > -VelocityClamp)
            {
                Rb.AddForce(Vector2.down * movementSpeed * Time.deltaTime);
            }
        }
    }
    

    void Rotate()
    {
        if (Mathf.Abs(Controller.state[player].ThumbSticks.Right.X) > thumbstickDeadZone || Mathf.Abs(Controller.state[player].ThumbSticks.Right.Y) > thumbstickDeadZone)
        {
            float heading = -Mathf.Atan2(Controller.state[player].ThumbSticks.Right.X, Controller.state[player].ThumbSticks.Right.Y);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg), Time.deltaTime * currentTurnSpeed);
        }
    }
}
