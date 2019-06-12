using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float flyTime;
    public Collider childCollider;
    public float stopTime = 5f;

    bool flying = true;
    
    Transform thisAnchor;
    Rigidbody rb;

    void Start ()
    {

        stopTime = Time.time + flyTime;

        rb = GetComponent<Rigidbody> ();
        childCollider = transform.GetChild (0).GetComponent<Collider> ();
    }

    void Update ()
    {
        //Kill if flying for too long
        if (stopTime <= Time.time && flying)
        {
            Destroy (this.gameObject);
        }

        if (flying)
        {
            Rotate ();
        } else if (thisAnchor != null)
        {
            transform.position = thisAnchor.transform.position;
            transform.rotation = thisAnchor.transform.rotation;
        }
    }

    void OnCollisionEnter (Collision other)
    {
        if (flying && other.transform.tag != "wall")
        {
            flying = false;
            transform.position = other.contacts[0].point;
            childCollider.isTrigger = true;

            GameObject anchor = new GameObject ("ArrowAnchor");
            anchor.transform.position = transform.position;
            anchor.transform.rotation = transform.rotation;
            anchor.transform.parent = other.transform;
            thisAnchor = anchor.transform;

            Destroy (rb);
            other.gameObject.SendMessage ("arrowHit", SendMessageOptions.DontRequireReceiver);
        }
    }

    void Rotate ()
    {
        transform.LookAt (transform.position + rb.velocity);
    }
}
