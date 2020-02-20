using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class Player_Movement : NetworkBehaviour {

    NavMeshAgent playerAgent;

    public float speed = 80f;
    public float turnSpeed = 5f;

    private Vector3 inputValue;
    private float powerInput;
    private float turnInput;
    private Rigidbody ShipRigid_Body;

    private void Awake()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        ShipRigid_Body = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        ShipRigid_Body.isKinematic = false;

        powerInput = 0f;
        turnInput = 0f;
    }

    private void OnDisable()
    {
        ShipRigid_Body.isKinematic = true;
    }

    void FixedUpdate()
    {
        Turn();
        Move();
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        Vector3 movement = transform.forward * powerInput * speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        ShipRigid_Body.MovePosition(ShipRigid_Body.position + movement);
    }

    private void Turn()
    {
        float turn = turnInput * turnSpeed * Time.deltaTime;

        // Make this into a rotation in the y axis.
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody's rotation.
        ShipRigid_Body.MoveRotation(ShipRigid_Body.rotation * turnRotation);
    }

    void GetInteraction()
    {
        Ray interactionRay =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable Object")
            {
                Debug.Log("interactable object");
            }
            else
            {
                playerAgent.destination = interactionInfo.point;
            }
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<Camera>().enabled = true;
        Color newSailColor = new Color(Random.value, Random.value, Random.value);
        Renderer sail_colors = GetComponent<Renderer>();
        //sail_colors.material.color = newSailColor;
        base.OnStartLocalPlayer();
    }
}
