using UnityEngine;

public class AddSpeedOnTrigger : MonoBehaviour
{
    public string targetTag;
    public GameManager gameManager;

    private Vector3 previousPosition;
    private Vector3 velocity;
    private Collider clubCollider;

    void Start()
    {
        previousPosition = transform.position;
        clubCollider = GetComponent<Collider>();

        Rigidbody rb = transform.parent.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = transform.parent.gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
        }
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        velocity = (transform.position - previousPosition) / Time.fixedDeltaTime;
        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Rigidbody rb = other.attachedRigidbody;
            if (rb == null) return;

            Vector3 direction;
            float distance;

            if (Physics.ComputePenetration(clubCollider, clubCollider.transform.position, clubCollider.transform.rotation, 
                                           other, other.transform.position, other.transform.rotation, 
                                           out direction, out distance))
            {
                rb.position += direction * distance;
            }

            Vector3 collisionPosition = clubCollider.ClosestPoint(other.transform.position);
            Vector3 collisionNormal = (other.transform.position - collisionPosition).normalized;

            Vector3 relativeVelocity = velocity - rb.velocity;

            float angleFactor = Mathf.Max(0, Vector3.Dot(relativeVelocity.normalized, collisionNormal));
            float forceMagnitude = relativeVelocity.magnitude * angleFactor * 1.5f;


            if (forceMagnitude > 1.0f)
            {
                Vector3 force = collisionNormal * forceMagnitude;
                rb.AddForce(force, ForceMode.Impulse);

                gameManager.nombreCoup++;
            }
        }
    }
}
