using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 _offset;
    
    void Start()
    {
        _offset = this.transform.position - target.transform.position;
    }
    
    void LateUpdate()
    {
        this.transform.position = target.transform.position + _offset;
    }
}