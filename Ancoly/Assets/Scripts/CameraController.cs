using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed = 5f;
    public Transform target;
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}
