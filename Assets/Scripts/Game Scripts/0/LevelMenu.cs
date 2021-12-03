using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void ReplayLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void NextLevel(){
        print("pressing");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void goHome(){
        SceneManager.LoadScene(0);
    }
}
