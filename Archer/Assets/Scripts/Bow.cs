using UnityEngine;

public class Bow : MonoBehaviour
{
    public float maxPower;
    public float powerIncreaseRate;

    public GameObject arrow;
    public Transform arrowBarrel;
    public GameObject staticArrow;

    public Transform stringBone, rotateBoneTop, rotateBoneBottom;
    Vector3 originalStringBonePos;
    Vector3 originalTopPos, originalBotPos;
    Vector3 originalStaticArrowPos;
    Quaternion originalTopRot, originalBotRot;
    bool pulling = false;
    float power = 0;

    void Start ()
    {
        originalStringBonePos = stringBone.localPosition;
        originalBotRot = rotateBoneBottom.localRotation;
        originalTopRot = rotateBoneTop.localRotation;
        originalTopPos = rotateBoneTop.localPosition;
        originalBotPos = rotateBoneBottom.localPosition;
        originalStaticArrowPos = staticArrow.transform.localPosition;
    }

    void OnGUI ()
    {
        GUI.Box (new Rect (0, 0, 100, 50), power.ToString ());
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown (0))
        {
            StartPull ();
        }

        if (Input.GetMouseButtonUp (0))
        {
            StopPull ();
        }

        if (pulling)
        {


            if (power < maxPower)
            {
                stringBone.Translate (Vector3.up * Time.deltaTime);
                rotateBoneTop.RotateAround (transform.position, new Vector3(1f, 0f, 0f), 0.5f);
                rotateBoneBottom.RotateAround (transform.position, new Vector3 (-1f, 0f, 0f), 0.5f);
                staticArrow.transform.Translate (Vector3.back * Time.deltaTime);
                power += powerIncreaseRate;
            } else
                power = maxPower;            
        }
    }

    void StartPull ()
    {
        pulling = true;
        power = 0;
    }

    void StopPull ()
    {
        pulling = false;
        stringBone.localPosition = originalStringBonePos;
        rotateBoneBottom.localRotation = originalBotRot;
        rotateBoneTop.localRotation = originalTopRot;
        rotateBoneTop.localPosition = originalTopPos;
        rotateBoneBottom.localPosition = originalBotPos;
        staticArrow.transform.localPosition = originalStaticArrowPos;
        Fire ();
    }

    void Fire ()
    {
        GameObject arrow = SpawnArrow ();

        Rigidbody arrowRb = arrow.GetComponent<Rigidbody> ();

        arrowRb.AddRelativeForce (Vector3.forward * power);
    }

    GameObject SpawnArrow ()
    {
        GameObject obj = (GameObject) Instantiate (arrow, arrowBarrel.position, arrowBarrel.rotation);

        return obj;
    }
}
