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

    PlayerEyes glowingEyes;
    private void Awake()
    {
        _maskSwitch = GetComponent<MaskSwitch>();
        glowingEyes = GetComponentInChildren<PlayerEyes>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x > 0)
        {
            glowingEyes.ChangeLeft(false);
            glowingEyes.ChangeRight(true);
        }
        else if (movement.x < 0) 
        {
            glowingEyes.ChangeLeft(true);
            glowingEyes.ChangeRight(false);
        }
        if(movement.y > 0) 
        {
            glowingEyes.ChangeLeft(false);
            glowingEyes.ChangeRight(false);
        }
        else if(movement.y < 0) 
        {
            glowingEyes.ChangeLeft(true);
            glowingEyes.ChangeRight(true);
        }
        if(movement.x == 0 && movement.y == 0) 
        {
            glowingEyes.ChangeLeft(true);
            glowingEyes.ChangeRight(true);
        }
        if (_maskSwitch)
        {
            _maskSwitch.SwitchForMovement(movement);
        }
        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
