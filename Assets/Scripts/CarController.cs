using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 120f;
    public float nitroSpeed = 30f;

    public Joystick joystick;

    private Rigidbody rb;
    private AudioSource engineAudio;

    private float moveInput;
    private float turnInput;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        engineAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        float keyboardMove = Input.GetAxis("Vertical");
        float keyboardTurn = Input.GetAxis("Horizontal");

        float joystickMove = 0f;
        float joystickTurn = 0f;

        if (joystick != null)
        {
            joystickMove = joystick.Vertical;
            joystickTurn = joystick.Horizontal;
        }

        moveInput = Mathf.Abs(joystickMove) > 0.1f ? joystickMove : keyboardMove;
        turnInput = Mathf.Abs(joystickTurn) > 0.1f ? joystickTurn : keyboardTurn;

        if (engineAudio != null)
        {
            if (Mathf.Abs(moveInput) > 0.1f && !engineAudio.isPlaying)
                engineAudio.Play();

            if (Mathf.Abs(moveInput) <= 0.1f && engineAudio.isPlaying)
                engineAudio.Stop();
        }
    }

    void FixedUpdate()
    {
        currentSpeed = NitroButton.nitroPressed ? nitroSpeed : speed;

        Vector3 moveVelocity = transform.forward * moveInput * currentSpeed;
        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);

        if (Mathf.Abs(moveInput) > 0.1f)
        {
            Quaternion turnRotation = Quaternion.Euler(
                0,
                turnInput * turnSpeed * Time.fixedDeltaTime,
                0
            );

            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}