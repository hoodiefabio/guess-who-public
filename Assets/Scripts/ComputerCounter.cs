using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerCounter : MonoBehaviour
{

    [SerializeField] ComputerTurn ComputerTurn;
    [SerializeField] Text counterText;


    void Start()
    {
        UpdateCounter();
    }

    public void UpdateCounter()
    {
        counterText.text = "Computer heeft nog: " + ComputerTurn.computerPeople.Count + " personen";
    }
}
