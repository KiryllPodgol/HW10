using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private float smoothSpeed;

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Цель не назначена!");
            return;
        }
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
     
    }
}
