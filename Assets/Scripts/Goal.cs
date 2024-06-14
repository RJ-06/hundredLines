using UnityEngine;
public class Goal : MonoBehaviour {
    public int score = 0;
    int winScore = 3;
    public NextScene next;
    public Transform[] resetPos;
    [SerializeField] GameObject[] players;
    [SerializeField] GameObject[] stageHazards;
    [SerializeField] ParticleSystem p;
    private void Awake(){ resetStage();}
    private void OnTriggerEnter2D(Collider2D collision){ 
        if (collision.CompareTag("ball")) {
            score++; 
            collision.transform.position = resetPos[0].position;
            for (int i = 0; i < players.Length; i++) { players[i].transform.position = resetPos[i + 1].position;}
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            p.Stop();
            p.Play();
            resetStage();
        }
    }
    private void resetStage() {
        foreach (var t in stageHazards){
            t.SetActive(false);
            if (Random.value < 0.25f) t.SetActive(true);
        }
    }
    private void Update(){ if (score >= winScore) next.goToNextScene();}
}