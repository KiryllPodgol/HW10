using UnityEngine;

public class CamControll : MonoBehaviour
{
   [SerializeField] private Transform target; 
   [SerializeField] private float smoothSpeed; 

    private void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3 (transform.position.y, transform.position.z), smoothSpeed *Time.deltaTime);
    }
}