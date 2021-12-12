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
        SceneManager.LoadScene(10);
    }

    public void registerButton(){
        SceneManager.LoadScene(11);
    }

    public void loginButton(){
        SceneManager.LoadScene(6);
    }

    public void okButton(){
        SceneManager.LoadScene(1);
    }

    private void Update() {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
