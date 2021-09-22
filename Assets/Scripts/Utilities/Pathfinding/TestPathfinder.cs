using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPathfinder : MonoBehaviour
{
    public Node startNode;
    public Node endNode;

    public Pathfinding pathfinding;

    public WalkabilityMask mask;

    List<Node> path;

    void Start()
    {
        path = new List<Node>();
        startNode = null;
        endNode = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            startNode = pathfinding.GetNearestNode(worldPos, out float distance);

            if (endNode != null)
            {
                path = pathfinding.FindPath(startNode, endNode, mask);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            endNode = pathfinding.GetNearestNode(worldPos, out float distance);

            if (startNode != null)
            {
                path = pathfinding.FindPath(startNode, endNode, mask);
            }
        }

        if (path != null)
        {
            for (int i = 1; i < path.Count; i++)
            {
                Debug.DrawLine(path[i-1].transform.position, path[i].transform.position);
            }
        }
    }
}
