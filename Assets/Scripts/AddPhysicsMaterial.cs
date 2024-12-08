using UnityEngine;

public class AddPhysicsMaterial : MonoBehaviour
{
    void Start()
    {
        Collider collider = GetComponent<Collider>();
        PhysicMaterial mat = new PhysicMaterial();
        mat.frictionCombine = PhysicMaterialCombine.Maximum;
        mat.dynamicFriction = 0.6f;
        mat.staticFriction = 0.6f;
        collider.material = mat;
    }
}
