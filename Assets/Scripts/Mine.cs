using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mine : MonoBehaviour {
    [SerializeField] float boomRad;
    [SerializeField] float force;
    [SerializeField] GameObject p;
    public void Explode() {
        p.SetActive(true);
        Collider2D[] nearColliders = Physics2D.OverlapCircleAll((Vector2)transform.position, boomRad);
        foreach (Collider2D collider in nearColliders) if (collider.gameObject.GetComponent<Rigidbody2D>() != null) collider.gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2)collider.transform.position - (Vector2)this.transform.position).normalized * force);
        Destroy(gameObject, .3f);
        //gameObject.SetActive(false);
    }
}