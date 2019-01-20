using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeName : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText = null;
    [SerializeField]
    private Text newNameText = null;

    void Start()
    {
        if(PlayerInfo.playerName != null && PlayerInfo.playerName != nameText.text) {
            nameText.text = PlayerInfo.playerName;
        }
    }

    public void ChangeNameText()
    {
        if(newNameText.text != "") {
            nameText.text = newNameText.text;
            PlayerInfo.playerName = newNameText.text;
        }

    }
}
