using UnityEngine;

public class CamControll : MonoBehaviour
{
  
    [SerializeField] private Transform target; 
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset; 

    void LateUpdate()
    {
        
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}

