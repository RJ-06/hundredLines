using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    private string[,] controls = { { "Horizontal1", "Vertical1","Mine1","Detonate1"}, { "Horizontal2", "Vertical2","Mine2","Detonate2"} };
    [SerializeField] int player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] GameObject mine;
    public List<GameObject> minesPlaced;
    private float inputTimer;
    [SerializeField] float TimeBetweenInputs;
    [SerializeField] float waitTime;
    [SerializeField] float kickForce;
    void FixedUpdate(){
        inputTimer += Time.deltaTime;
        Vector2 fAdd = new Vector2(Input.GetAxisRaw(controls[player, 0]), Input.GetAxisRaw(controls[player, 1])).normalized * speed;
        if (Mathf.Sign(fAdd.x) == -Mathf.Sign(rb.velocity.x) && fAdd.x!=0) rb.velocity = new Vector2(0,rb.velocity.y);
        if (Mathf.Sign(fAdd.y) == -Mathf.Sign(rb.velocity.y) && fAdd.y != 0) rb.velocity = new Vector2(rb.velocity.x,0);
        rb.AddForce(fAdd);
        if (Input.GetAxisRaw(controls[player, 3]) > 0) StartCoroutine(callExplode());
        if (Input.GetAxisRaw(controls[player, 2]) > 0 && minesPlaced.Count < 3 && inputTimer>=TimeBetweenInputs) {
            minesPlaced.Add(Instantiate(mine, transform.position, Quaternion.identity));
            inputTimer = 0;
        }
    }
    IEnumerator callExplode() {
        for (int i = 0; i < minesPlaced.Count; i++) {
            minesPlaced[i].GetComponent<Mine>().Explode();
            yield return new WaitForSeconds(waitTime);
        }
        minesPlaced.Clear();
    }
    private void OnCollisionEnter2D(Collision2D collision){ if(collision.gameObject.CompareTag("ball"))collision.gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2)collision.transform.position - (Vector2)this.transform.position).normalized * kickForce);}
}