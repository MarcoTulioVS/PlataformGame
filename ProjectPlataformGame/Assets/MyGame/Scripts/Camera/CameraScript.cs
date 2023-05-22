using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float maxX;

    [SerializeField]
    private float maxY;

    [SerializeField]
    private float minX;

    [SerializeField]
    private float minY;

    public Transform target;

    void Awake()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minX, maxX), Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
    }
}
