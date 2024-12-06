using UnityEngine;

public class ColliderDebugger : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Collider collider = GetComponent<Collider>();
        
        if (collider != null)
        {
            Gizmos.color = Color.red;

            // Handle different types of colliders
            if (collider is BoxCollider boxCollider)
            {
                Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
            }
            else if (collider is SphereCollider sphereCollider)
            {
                Gizmos.DrawWireSphere(sphereCollider.bounds.center, sphereCollider.radius);
            }
            else if (collider is CapsuleCollider capsuleCollider)
            {
                Gizmos.DrawWireSphere(capsuleCollider.bounds.center, capsuleCollider.radius);
                // Draw the capsule shape manually, if needed
            }
            else if (collider is MeshCollider meshCollider)
            {
                if (!meshCollider.convex)  // For non-convex mesh colliders, this will work better
                {
                    Gizmos.DrawWireMesh(meshCollider.sharedMesh, collider.transform.position, collider.transform.rotation, collider.transform.localScale);
                }
            }
        }
    }
}
