using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private float upSpeed = 10f;
    private float speed = 0f;
    private float maxSpeed = 22f;

    private Rigidbody rb;
    private Collider boxCol;
    private bool hovering = true;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCol = GetComponent<BoxCollider>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Quaternion deviceRotation = DeviceRotation.Get();
        transform.rotation = deviceRotation;

        if (hovering)
        {
            rb.AddForce(transform.up * upSpeed, ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(transform.forward * speed, ForceMode.Force);
        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }

    public void Hover()
    {
        upSpeed = 10f;
        speed = 0f;
        rb.useGravity = true;
        hovering = true;
        GetComponent<Animation>().Play("sj001_wait");
        GetComponent<AudioSource>().pitch = 1f;
    }

    public void Fly()
    {
        upSpeed = 0f;
        speed = 22f;
        rb.useGravity = false;
        hovering = false;
        GetComponent<Animation>().Play("sj001_run");
        GetComponent<AudioSource>().pitch = 1.61f;
    }
}
        


