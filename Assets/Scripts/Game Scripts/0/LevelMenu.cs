using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void ReplayLevel(){
        SceneManager.LoadScene(GameState.currentScene);
    }

    public void NextLevel(){
        SceneManager.LoadScene(GameState.currentScene+1);
    }

    public void goHome(){
        SceneManager.LoadScene(0);
    }

    public void startButton(){
        SceneManager.LoadScene(3);
    }

    public void okButton(){
        SceneManager.LoadScene(1);
    }
}
