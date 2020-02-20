using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOnWater : MonoBehaviour {

    public float AdjustmentAmmount;

    private Transform seaPlane;
    private Cloth seaMesh;
    [SerializeField] private int closestVertexIndex = -1;

    // Use this for initialization
    void Start () {
        seaPlane = GameObject.Find("WaterPlane").transform;
        seaMesh = seaPlane.GetComponent<Cloth>();
    }
    
    void GetClostestVertex()
    {
        for (int i = 0; i < seaMesh.vertices.Length; i++)
        {
            if (closestVertexIndex == -1)
            {
                closestVertexIndex = i;
            }
            float distance = Vector3.Distance(seaMesh.vertices[i], transform.position);
            float closestDistance = Vector3.Distance(seaMesh.vertices[closestVertexIndex], transform.position);

            if (distance < closestDistance)
            {
                closestVertexIndex = i;
            }
        }

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            seaMesh.vertices[closestVertexIndex].y - AdjustmentAmmount,
            transform.localPosition.z);
    }

    // Update is called once per frame
    void Update () {
        GetClostestVertex();
    }

}
