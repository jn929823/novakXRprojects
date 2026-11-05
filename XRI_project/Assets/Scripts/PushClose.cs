using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Unity.VisualScripting;

public class PushClose : CoreFeatures
{
    [Header("Push")]
    [SerializeField]
    private Transform pushableObject;

    [SerializeField]
    private Grabbable grabbable;

    [SerializeField]
    private float snapDistance = 0.04f; //closes drawer once it is <= 0.04 cm

    private float closedZ;
    private Bounds bounds; //size of mesh. Where is front side
    private PokeInteractor[] fingers; //should work for controller as well
    private readonly Dictionary<PokeInteractor, bool> wasInFront = new Dictionary<PokeInteractor, bool>();




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
