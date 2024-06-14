using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour{
    [SerializeField] int nextScene;
    public void goToNextScene() { SceneManager.LoadScene(nextScene);}
}