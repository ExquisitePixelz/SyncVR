using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class difficiltySettings : MonoBehaviour
{
    public string[] gameDifficultySetting = { "beginner", "easy", "medium", "hard", "extreme" };
    public string[] gameDifficultyText = { "2 objects to find", "5 objects to find", "10 objects to find", "15 objects to find", "20 objects to find" };
    public TMP_Text DifficultySetting;
    public TMP_Text DifficultyText;

    public void setDifficulty()
    {
        GameManager.difficultySetting = (int)GetComponent<Slider>().value;
        DifficultySetting.text = gameDifficultySetting[(int)GetComponent<Slider>().value];
        DifficultyText.text = gameDifficultyText[(int)GetComponent<Slider>().value];
    }
}
