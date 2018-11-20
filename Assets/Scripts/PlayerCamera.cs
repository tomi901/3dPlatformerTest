using UnityEngine;


public class PlayerCamera : MonoBehaviour
{

    [SerializeField]
    private Transform target = null;

    [SerializeField]
    private float distance = 5f;

    [SerializeField]
    private Vector2 sensitivity = Vector2.one;

    [SerializeField]
    // In radians
    private Vector2 currentAngle = Vector2.zero;

    private void LateUpdate()
    {
        float yCos = Mathf.Cos(currentAngle.y);
        Vector3 targetPos = new Vector3(
            Mathf.Sin(currentAngle.x) * yCos,
            Mathf.Sin(currentAngle.y), 
            Mathf.Cos(currentAngle.x) * yCos
            );
        targetPos *= distance;
        transform.position = targetPos + target.position;

        transform.rotation = Quaternion.LookRotation(-targetPos, Vector3.up);
    }

}
