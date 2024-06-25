using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinder : MonoBehaviour
{
    public Transform target;
    public float speed = 2.0f;
    private List<Vector3> path = new List<Vector3>();
    private int currentPathIndex = 0;

    void Start()
    {
        path = FindPath(transform.position, target.position);
    }

    void Update()
    {
        if (currentPathIndex < path.Count)
        {
            Vector3 nextPoint = path[currentPathIndex];
            transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, nextPoint) < 0.1f)
            {
                currentPathIndex++;
            }
        }
    }

    public List<Vector3> FindPath(Vector3 start, Vector3 end)
    {
        List<Vector3> foundPath = new List<Vector3>();
        // ... (Code A* pathfinding)
        return foundPath;
    }
}
