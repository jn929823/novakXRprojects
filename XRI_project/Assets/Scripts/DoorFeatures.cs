using JetBrains.Annotations;
using Mono.Cecil.Cil;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class DoorFeatures : CoreFeatures
{
    [Header("Door Configuration")]

    [SerializeField]
    private Transform doorPivot; //Pivot Control

    [SerializeField]
    private float maxAngle = 90.0f; //current guess of maxAngle

    [SerializeField]
    private float doorSpeed = 1.0f; //current guess of doorSpeed

    [SerializeField]
    private bool reverseAngleDirection = false;

    [SerializeField]
    private bool doorOpen = false;

    [SerializeField]
    private bool MakeKinematicOnOpen = false;


    [Header("Interactions Configuration")]

    [SerializeField]
    private XRSocketInteractor socketInteractor; //Trigger by "Events"

    [SerializeField]
    private XRSimpleInteractable simpleInteractable;

    private void Start()
    {
        //when a key gets close to a socket, add a listener
        //s = Select Enter or Exit

        socketInteractor?.selectEntered.AddListener((s) =>
        {
            OpenDoor();
            PlayOnStart();
        });

        socketInteractor?.selectExited.AddListener((S) =>
        {
            PlayOnEnd();
            socketInteractor.socketActive = featureUsage == FeatureUsage.Once ? false : true;
        });

        simpleInteractable?.selectEntered.AddListener((s) =>
        {
            OpenDoor();
        });

        //REMOVE THIS - TESTING ONLY
        OpenDoor();
    }
    public void OpenDoor()
    {
        //if the door is not open, play OnStart sound

        if (!doorOpen)
        {
            PlayOnStart();
            doorOpen = true;
            StartCoroutine(ProcessMotion());
        }
    }
    private IEnumerator ProcessMotion()
    {
        //Keep looking to confirm the door is open

        while (doorOpen)
        {
            var angle = doorPivot.localEulerAngles.y < 180 ? doorPivot.localEulerAngles.y : doorPivot.localEulerAngles.y - 360;
            angle = reverseAngleDirection ? Mathf.Abs(angle) : angle;
            if (angle <= maxAngle)
            {
                doorPivot?.Rotate(Vector3.up, doorSpeed * Time.deltaTime * (reverseAngleDirection ? -1 : 1));
            }
            else //when done, turn on Rigidbody
            {
                doorOpen = false;
                var featureRigidbody = GetComponent<Rigidbody>();
                if (featureRigidbody != null && MakeKinematicOnOpen) featureRigidbody.isKinematic = true;
            }
            yield return null;
        }
    }
}