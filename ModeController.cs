using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeController : MonoBehaviour
{
    [SerializeField] Text stateTitle;
    InstantiateObjects instantiateSystem;
    PathCreator[] pathCreationSystems;
    PathMover[] pathMovers;

    void Start()
    {
        pathCreationSystems = FindObjectsOfType<PathCreator>();
        pathMovers = FindObjectsOfType<PathMover>();
        instantiateSystem =  FindObjectOfType<InstantiateObjects>();

        foreach (var system in pathCreationSystems) // default mode
            system.gameObject.SetActive(false); 
    }
    public void TurnOnBuildMode()
    {
        instantiateSystem.gameObject.SetActive(true);
        foreach (var system in pathCreationSystems)
            system.gameObject.SetActive(false); 

        stateTitle.text = "Стройка";
    }
    public void TurnOnMoveMode()
    {
        foreach (var system in pathCreationSystems)
            system.gameObject.SetActive(true);
        instantiateSystem.gameObject.SetActive(false);

        stateTitle.text = "Движение";
    }
}
