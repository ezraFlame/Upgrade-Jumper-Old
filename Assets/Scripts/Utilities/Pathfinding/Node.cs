using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Node : MonoBehaviour
{
    public int gCost;
    public int hCost;
    public int fCost;

    public Node previousNode;

    public WalkabilityMask currentWalkability;

    public List<NodeConnection> connections;

    void Start()
    {
        previousNode = null;
        gCost = int.MaxValue;

        foreach (NodeConnection connection in connections)
        {
            connection.CalculateCost();
        }
    }

    private void Update()
    {
        foreach (NodeConnection connection in connections)
        {
            connection.CalculateCost();
        }
    }

    public void CalculateCost()
    {
        fCost = gCost + hCost;
    }

    private void OnDrawGizmos()
    {
        Node node = this;
    }

    [CustomEditor(typeof(Node))]
    class NodeEditor : Editor
    {
        Node node;

        private void OnEnable()
        {
            node = (Node)target;
        }

        private void OnSceneGUI()
        {
            foreach (NodeConnection connection in node.connections)
            {
                if (connection.nodes.Length == 2)
                {
                    Handles.DrawAAPolyLine(connection.nodes[0].transform.position, connection.nodes[1].transform.position);
                    Vector3 between = Vector3.Lerp(connection.nodes[0].transform.position, connection.nodes[1].transform.position, 0.5f);
                    between += Vector3.up * 0.5f;
                    Handles.Label(between, connection.cost + "");
                }
            }
        }
    }

    public override string ToString()
    {
        return "g: " + gCost + ", h: " + hCost + ", f: " + fCost;
    }
}
