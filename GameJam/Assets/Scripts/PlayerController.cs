using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    private bool jump;
    private bool dash;
    private bool singleShot;
    private bool autoShot;

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

        if (!singleShot)
        {
            singleShot = Input.GetButtonDown("Fire1");
        }
        
        if (!autoShot)
        {
            autoShot = Input.GetButton("Fire1");
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        motor.Move(move, jump);
        motor.Dash(dash);
        motor.ShootInput(singleShot, autoShot);

        jump = false;
        dash = false;
        singleShot = false;
        autoShot = false;
    }
}