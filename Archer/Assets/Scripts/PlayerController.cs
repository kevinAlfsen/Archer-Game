using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 10;
    public float lookSens = 3f;
    public Transform face;
    public Rigidbody rb;

    float xDir, yDir, zDir;
    float xRot, yRot;

    void Start ()
    {
        rb = GetComponent<Rigidbody> ();
    }

    void Update ()
    {
        Movement ();
        Rotation ();
        Mathf.Clamp (transform.position.x, -10, 10);
    }

    void Movement ()
    {
        xDir = Input.GetAxisRaw ("Horizontal");
        yDir = 0;
        zDir = Input.GetAxisRaw ("Vertical");

        Vector3 dir = new Vector3 (xDir, yDir, zDir);
        transform.Translate (dir * speed * Time.deltaTime);
    }

    void Rotation ()
    {
        //Calculate rotation
        yRot = Input.GetAxisRaw ("Mouse X");
        xRot = Input.GetAxisRaw ("Mouse Y");

        Vector3 yRotation = new Vector3 (0f, yRot, 0f) * lookSens;
        rb.MoveRotation (rb.rotation * Quaternion.Euler (yRotation));

        Vector3 xRotation = new Vector3 (xRot, 0f, 0f) * lookSens;
        face.transform.Rotate (-xRotation);
    }

    Vector3 ClampMovement ()
    {
        return Vector3.zero;
    }
}
