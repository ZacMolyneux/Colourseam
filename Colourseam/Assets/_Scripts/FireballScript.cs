using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour
{
    public float speed;

    Rigidbody2D Rb;

    float durationTimer;
    public float ignoreTime;

    public Collider2D playerCollider;

	// Use this for initialization
	void Start ()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        durationTimer += Time.deltaTime;
        if(durationTimer < ignoreTime)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, false);
        }
    }
}
