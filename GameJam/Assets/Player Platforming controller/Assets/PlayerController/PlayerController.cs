using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private bool jump;
    private bool dash;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (!jump)
        {
            jump = Input.GetButtonDown("Jump");
        }

        if (!dash)
        {
            dash = Input.GetButtonDown("Fire2");
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        motor.Move(move, jump);
        motor.Dash(vert, dash);

        jump = false;
        dash = false;
    }
}