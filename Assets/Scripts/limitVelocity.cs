using UnityEngine;
public class limitVelocity : MonoBehaviour{
    [SerializeField] float speedLimit;
    [SerializeField] Rigidbody2D rb;
    void LateUpdate(){ if (rb.velocity.magnitude > speedLimit) rb.AddForce(-(rb.velocity.magnitude - speedLimit) * rb.velocity.normalized);}
}