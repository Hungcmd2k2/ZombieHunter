using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public Seeker seeker;
    public Transform target;
    public float nextWPDistance;
    public float Speed;
    public SpriteRenderer spriteRenderer;
    Path path;
    Coroutine moveCoroutine;
    private void Start()
    {

        InvokeRepeating("CalculatePath", 0f, 10f);
    }
    void CalculatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, OnPathCallback);
        }
    }
    void OnPathCallback(Path p)
    {
        if (p.error)
        {
            return;
        }
        else
        {
            path = p;
            MoveTarget();
        }

    }
    void MoveTarget()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        else
        {
            moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
        }
    }
    IEnumerator MoveToTargetCoroutine()
    {
        int currenWP = 0;
        while (currenWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currenWP] - (Vector2)transform.position).normalized;
            Vector3 force = direction * Speed * Time.deltaTime;
            transform.position += force;
            float distance = Vector2.Distance(transform.position, path.vectorPath[currenWP]);
            if (distance < nextWPDistance)
            {
                currenWP++;
            }
            if (force.x != 0)
            {
                if (force.x < 0)
                {
                    spriteRenderer.transform.localScale = new Vector3(-1, 1, 0);

                }
                else
                {
                    spriteRenderer.transform.localScale = new Vector3(1, 1, 0);
                }
                yield return null;
            }
        }
    }
}
