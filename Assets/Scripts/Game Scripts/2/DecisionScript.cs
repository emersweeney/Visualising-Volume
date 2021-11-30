using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
            if (i==indexCorrectButton) buttons[i].onClick.AddListener(correctAnswer);
            else buttons[i].onClick.AddListener(incorrectAnswer);
        }
    }

    private void correctAnswer(){}
    private void incorrectAnswer(){}
}
