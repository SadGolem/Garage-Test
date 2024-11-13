using UnityEngine;

public class Item : MonoBehaviour
{
    public Rigidbody rb;
    public Transform _transform;
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        _transform = this.transform;
        rb.mass = 10f;
        rb.drag = 1f;
        rb.angularDrag = 10f;

        MeshCollider collider = gameObject.AddComponent<MeshCollider>();

        collider.isTrigger = false; 
        collider.convex = true;
    }
    
}
