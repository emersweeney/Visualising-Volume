using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DecisionScript : MonoBehaviour
{
    [SerializeField] private Text textButton;
    [SerializeField] private Button button0, button1, button2;
    private List<Button> buttons;
    private int indexCorrectButton;
    private string message;

    private void Start(){
        buttons = new List<Button>{button0, button1, button2};
        indexCorrectButton = GameState.correctAnswer;
        message = GameState.displayMessage;
        textButton.text = message;
        
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i==indexCorrectButton) {
                print("correct button = "+i);
                buttons[i].onClick.AddListener(correctAnswer);
            }
            else {
                print("incorrect button = "+i);
                buttons[i].onClick.AddListener(incorrectAnswer);
            }
        }
    }

    public void correctAnswer(){
        print("correct answer pressed");
        GameState.choseCorrectly = true;
        SceneManager.LoadScene(4);
    }
    public void incorrectAnswer(){
        GameState.choseCorrectly = false;
        SceneManager.LoadScene(4);
    }
}
