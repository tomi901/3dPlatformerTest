using UnityEngine;


public class SpriteLookToCamera : MonoBehaviour
{

    private void LateUpdate()
    {
        Vector3 lookDirection = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    }

}
