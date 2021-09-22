using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Pathfinding pathfinding;

    public List<Node> poi;
    public List<Node> path;
    public WalkabilityMask mask;

    public Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    public float nextNodeDistance;

    public Transform wallCheck;
    public float wallCheckDistance;
    public Transform groundCheck;
    public float groundCheckDistance;

    public bool alreadyJumped = false;

    public LayerMask ground;



    void Start()
    {
        path = new List<Node>();
        path = pathfinding.FindPath(pathfinding.GetNearestNode(transform.position), poi[0], mask);

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, path[path.Count - 1].transform.position) <= nextNodeDistance)
        {
            //cycle through poi's
            Node node1 = poi[0];
            poi.RemoveAt(0);
            poi.Add(node1);
            path = pathfinding.FindPath(pathfinding.GetNearestNode(transform.position), poi[0], mask);
        }

        if (Vector2.Distance(transform.position, path[0].transform.position) <= nextNodeDistance)
        {
            //remove waypoints we've already reached
            path.RemoveAt(0);
        }

        //move and turn
        if (path[0].transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);

            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);

            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        //check if we're on the ground
        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckDistance, ground);

        if (grounded == true)
        {
            //if we're on the ground, reset this so we can jump
            alreadyJumped = false;
        } else if (grounded == false && alreadyJumped == false && path[0].transform.position.y > transform.position.y) {
            //jump when we're off the ground, but only if we haven't jumped yet
            alreadyJumped = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
