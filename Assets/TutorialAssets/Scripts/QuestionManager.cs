using System;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{

    [SerializeField] MonsterManager _monsterManager;
    [SerializeField] TMP_Text _messageBoxTextField;
    [SerializeField] TMP_InputField _answerInputField;

    [SerializeField] int answer;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateQuestions();
    }

    void generateQuestions ()
    {
        var qa = generateAddSub(1, 100);

        _messageBoxTextField.text = qa.question;

        clearInputField();
    }

    (string question, int answer) generateAddSub(int min, int max)
    {
        /*
        Find random values for the operation
        */
        int operand1 = UnityEngine.Random.Range(min, max);
        int operand2 = UnityEngine.Random.Range(min, max);

        string question = "";

        // Addition or Subtraction
        if (UnityEngine.Random.value < 0.5f)
        {
            question = $"{operand1} + {operand2} = ";
            answer = operand1 + operand2;
        }
        else
        {
            question = $"{operand1} - {operand2} = ";
            answer = operand1 - operand2;
        }
        return (question, answer);
    }

    public void validateAnswer()
    {
        if (_answerInputField.text == answer.ToString())
        {
            _monsterManager.KillMonster(0);
            _monsterManager.MonstersAttacks(0);
            _monsterManager.MoveNextMonsterToQueue();
            generateQuestions();
        }
        else 
        {
            clearInputField();
        }
    }

    void clearInputField()
    {
        _answerInputField.text = "";
        _answerInputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
