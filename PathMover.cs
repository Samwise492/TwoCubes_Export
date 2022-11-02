using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathMover : MonoBehaviour
{
    PathCreator pathCreator;
    NavMeshAgent navMeshAgent;
    public Queue<Vector3> pathPoints = new Queue<Vector3>();

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pathCreator = transform.GetChild(0).GetComponent<PathCreator>();

        pathCreator.OnNewPathCreated += SetPoints;
    }

    void SetPoints(IEnumerable<Vector3> points)
    {
        pathPoints = new Queue<Vector3>(points);
    }

    void Update()
    {
        UpdatePathing();
    }

    void UpdatePathing()
    {
        if (ShouldSetDestination())
            navMeshAgent.SetDestination(pathPoints.Dequeue());
    }

    bool ShouldSetDestination()
    {
        if (pathPoints.Count == 0)
            return false;

        if (navMeshAgent.hasPath == false || navMeshAgent.remainingDistance < 0.5f)
            return true;

        return false;
    }
}
