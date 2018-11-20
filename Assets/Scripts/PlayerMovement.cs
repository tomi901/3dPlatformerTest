using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float moveVelocity = 5f;
    [SerializeField]
    private float moveDamp = 10f;
    [SerializeField]
    private float slideValue = 0.7f;

    [Space]

    [SerializeField]
    private float jumpImpulse = 10f;


    private CharacterController controller;
    private Vector2 currentMovement, targetMovement;
    private float verticalVelocity;

    private bool isGrounded = false;
    private ControllerColliderHit lastHit;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        SetInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity += jumpImpulse;
        }
    }

    private void SetInput(float horizontal, float vertical)
    {
        SetInput(new Vector2(horizontal, vertical));
    }
    private void SetInput(Vector2 inputPlane)
    {
        targetMovement = Vector2.ClampMagnitude(inputPlane, 1f) * moveVelocity;
    }

    private void FixedUpdate()
    {
        currentMovement = Vector2.Lerp(currentMovement, targetMovement, moveDamp * Time.fixedDeltaTime);

        Vector3 forward = transform.position - Camera.main.transform.position;
        forward.y = 0;
        forward.Normalize();
        Vector3 right = new Vector3(forward.z, 0, -forward.x);

        Vector3 move = forward * currentMovement.y + right * currentMovement.x;
        move.y = verticalVelocity;

        if (!isGrounded && controller.isGrounded)
        {
            float slideThreshold = (1f - lastHit.normal.y) * slideValue;
            move.x = slideThreshold * lastHit.normal.x;
            move.z = slideThreshold * lastHit.normal.z;
        }

        controller.Move(move * Time.fixedDeltaTime);
        isGrounded = controller.isGrounded && (Vector3.Angle(Vector3.up, lastHit.normal) <= controller.slopeLimit);

        verticalVelocity = (isGrounded ? 0 : verticalVelocity) + Physics.gravity.y * Time.fixedDeltaTime;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        lastHit = hit;
    }

}
