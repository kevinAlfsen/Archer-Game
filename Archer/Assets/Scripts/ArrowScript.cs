using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour
{
    Vector3 originalLossyScale;
    Vector3 scaleFactor;

    Rigidbody rb;

    void Awake ()
    {
        rb = GetComponent<Rigidbody> ();
    }

    void OnTriggerEnter (Collider other)
    {
        rb.isKinematic = true;
        transform.parent = other.transform;
    }

    void ArrowHit ()
    {
        rb.isKinematic = true;
    }

}
