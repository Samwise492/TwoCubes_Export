using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] int cubeNumber;
    GameReloading reloadingSystem;
    PathMover pathMover;
    Rigidbody rb;

    void Start()
    {
        reloadingSystem = FindObjectOfType<GameReloading>();
        pathMover = GetComponent<PathMover>();
        rb = GetComponent<Rigidbody>();
        
        StartCoroutine(CheckForPathNullify());
    }
    void Update()
    {
        if (cubeNumber == 1)
        {
            if (reloadingSystem.winCounter == 1)
            {
                pathMover.enabled = false;
                rb.isKinematic = true;
            }
        }
        if (cubeNumber == 2)
        {
            if (reloadingSystem.winCounter == 1)
            {
                pathMover.enabled = true;
                rb.isKinematic = false;
            }
            else if (reloadingSystem.winCounter == 0)
            {
                pathMover.enabled = false;
                rb.isKinematic = true;
            }
        }
    }
    IEnumerator CheckForPathNullify()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            if (reloadingSystem.winCounter == 1)
            {
                pathMover.pathPoints = new Queue<Vector3> {};
                yield break;
            }
        }
    }
}
