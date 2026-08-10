using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 oppositePoint = transform.position - 
        (Camera.main.transform.position - transform.position);
        transform.LookAt(oppositePoint);
    }
}
