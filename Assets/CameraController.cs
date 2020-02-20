using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed = 5.0f;
    public Transform player;
  
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.LookAt(player);
            transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
        }
    }
}
