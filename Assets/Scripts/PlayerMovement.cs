using Masks;
using UnityEngine;

[RequireComponent(typeof(MaskSwitch))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3;
    public Rigidbody2D rb;

    public Animator playerAnimator;
    Vector2 movement;
    private MaskSwitch _maskSwitch;

    private void Awake()
    {
        _maskSwitch = GetComponent<MaskSwitch>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        _maskSwitch.SwitchForMovement(movement);

        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
