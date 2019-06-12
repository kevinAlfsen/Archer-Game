using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed = 10f;

    GameObject targetsHolder;
    Transform[] targetList;

    Transform currentTarget;
    Vector3 targetDirection;

    public GameManager gameManager;

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager> ();

        targetsHolder = GameObject.Find ("Targets");

        targetList = targetsHolder.GetComponent<TargetList> ().targets;

        FindTarget ();
    }

    void Update ()
    {
        CheckDestination (Vector3.Distance (transform.position, currentTarget.position));

        if (currentTarget != null)
            transform.Translate ((targetDirection) * Time.deltaTime * speed );


    }

    void CheckDestination (float distanceToTarget)
    {
        if (distanceToTarget < 0.5f)
        {
            Destroy (this.gameObject);
        }
    }

    void OnCollisionEnter (Collision other)
    {
        Destroy (this.gameObject);
        Destroy (other.gameObject);

        gameManager.UpdateScore (10);
    }

    void FindTarget ()
    {
        float shortestDistance = Mathf.Infinity;

        foreach (Transform t in targetList)
        {
            float distToTarget = Vector3.Distance (transform.position, t.position);

            if (distToTarget < shortestDistance)
            {
                shortestDistance = distToTarget;
                currentTarget = t;
            }
        }

        targetDirection = currentTarget.position - transform.position;
    }
}
