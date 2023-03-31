using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ComputerTurn : MonoBehaviour
{
    [SerializeField] PersonManager personManager;
    [SerializeField] GameObject playerWinScreen;
    [SerializeField] GameObject cpuWinscreen;
    [SerializeField] Image playerperson;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    [SerializeField] Text question;
    [SerializeField] public List<PersonInfo> computerPeople;
    private bool turnStart;
    private bool guessedOld;
    private bool guessedMale;
    private bool guessedGlasses;
    private bool guessedFacialHair;

    private bool guessedRedHair;
    private bool guessedBlueHair;
    private bool guessedBlackHair;
    private bool guessedRedEyes;
    private bool guessedBlueEyes;
    private bool guessedBlackEyes;

    private bool computerWin;
    // Start is called before the first frame update
    void Start()
    {
        playerperson.sprite = personManager.chosenPersonPlayer.sprite.sprite;
        turnStart = false;
        computerWin = false;
        guessedOld = false;
        guessedMale = false;
        guessedRedHair = false;
        guessedBlueHair = false;
        guessedBlackHair = false;
        guessedRedEyes = false;
        guessedBlueEyes = false;
        guessedBlackEyes = false;
        guessedGlasses = false;
        guessedFacialHair = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && !turnStart && !playerWinScreen.activeSelf)
        {
            RandomGuess();
            turnStart = true;
        }
    }

    public void RandomGuess()
    {
        if (computerPeople.Count <= 4)
        {
            GuessRandomPerson();
        }
        else
        {
            RandomQuestion();
        }     
    }

    public void RandomQuestion()
    {
        int randomGuess = Random.Range(-1, 10);
        if (randomGuess <= 0 && !guessedOld)
            GuessOld();
        else if (randomGuess == 1 && !guessedMale)
            GuessMale();
        else if (randomGuess == 2 && !guessedRedHair)
            GuessHairColor("grijs");
        else if (randomGuess == 3 && !guessedBlueHair)
            GuessHairColor("blond");
        else if (randomGuess == 4 && !guessedBlackHair)
            GuessHairColor("bruin");
        else if (randomGuess == 5 && !guessedRedEyes)
            GuessEyeColor("groene");
        else if (randomGuess == 6 && !guessedBlueEyes)
            GuessEyeColor("blauwe");
        else if (randomGuess == 7 && !guessedBlackEyes)
            GuessEyeColor("zwarte");
        else if (randomGuess == 8 && !guessedGlasses)
            GuessGlasses();
        else if (randomGuess == 9 && !guessedFacialHair)
            GuessFacialHair();
        else
        {
            RandomGuess();
        }
    }

    public void EndTurn()
    {
        if(computerWin)
        {
            cpuWinscreen.SetActive(true);
        }
        turnStart = false;
        playerperson.sprite = personManager.chosenPersonPlayer.sprite.sprite;
        playerperson.enabled = false;
        personManager.whosTurn *= -1;
    }

    private void GuessRandomPerson()
    {
        PersonInfo randomPerson = computerPeople[Random.Range(0, computerPeople.Count)];
        question.text = "Is dit uw persoon?";
        playerperson.sprite = randomPerson.sprite.sprite;
        playerperson.enabled = true;
        if (randomPerson.playerPicture)
        {
            noButton.interactable = false;
            yesButton.interactable = true;
            computerWin = true;
            computerPeople.RemoveAll(item => item.playerPicture == false);
        }
        else if (!randomPerson.playerPicture)
        {
            yesButton.interactable = false;
            noButton.interactable = true;
            computerPeople.Remove(randomPerson);
        }
    }

    public void GuessOld()
    {
        question.text = "Is uw persoon oud?";
        guessedOld = true;

        if (personManager.chosenPersonPlayer.old)
        {
            noButton.interactable = false;
            yesButton.interactable = true;
            computerPeople.RemoveAll(item => item.old == false);
        }
        else if (!personManager.chosenPersonPlayer.old)
        {
            yesButton.interactable = false;
            noButton.interactable = true;
            computerPeople.RemoveAll(item => item.old == true);
        }
    }

    public void GuessMale()
    {
        question.text = "Is uw persoon een man?";
        guessedMale = true;

        if (personManager.chosenPersonPlayer.male)
        {
            noButton.interactable = false;
            yesButton.interactable = true;
            computerPeople.RemoveAll(item => item.male == false);
        }
        else if (!personManager.chosenPersonPlayer.male)
        {
            yesButton.interactable = false;
            noButton.interactable = true;
            computerPeople.RemoveAll(item => item.male == true);
        }
    }

    public void GuessGlasses()
    {
        question.text = "Heeft uw persoon een bril?";
        guessedGlasses = true;

        if (personManager.chosenPersonPlayer.glasses)
        {
            noButton.interactable = false;
            yesButton.interactable = true;
            computerPeople.RemoveAll(item => item.glasses == false);
        }
        else if (!personManager.chosenPersonPlayer.glasses)
        {
            yesButton.interactable = false;
            noButton.interactable = true;
            computerPeople.RemoveAll(item => item.glasses == true);
        }
    }

    public void GuessFacialHair()
    {
        question.text = "Heeft uw persoon gezichtsbeharing?";
        guessedFacialHair = true;

        if (personManager.chosenPersonPlayer.facialHair)
        {
            noButton.interactable = false;
            yesButton.interactable = true;
            computerPeople.RemoveAll(item => item.facialHair == false);
        }
        else if (!personManager.chosenPersonPlayer.facialHair)
        {
            yesButton.interactable = false;
            noButton.interactable = true;
            computerPeople.RemoveAll(item => item.facialHair == true);
        }
    }
    public void GuessHairColor(string color)
    {
        question.text = "Heeft uw persoon " +color+ " haar?";
        

        if (personManager.chosenPersonPlayer.hairColor == color)
        {
            noButton.interactable = false;
            yesButton.interactable = true;
            computerPeople.RemoveAll(item => item.hairColor != color);
        }
        else if (personManager.chosenPersonPlayer.hairColor != color)
        {
            yesButton.interactable = false;
            noButton.interactable = true;
            computerPeople.RemoveAll(item => item.hairColor == color);
        }

        if (color == "grijs")
            guessedRedHair = true;
        else if (color == "blond")
            guessedBlueHair = true;
        else if (color == "bruin")
            guessedBlackHair = true;
    }

    public void GuessEyeColor(string color)
    {
        question.text = "Heeft uw persoon " + color + " ogen?";

        if (personManager.chosenPersonPlayer.eyeColor == color)
        {
            noButton.interactable = false;
            yesButton.interactable = true;
            computerPeople.RemoveAll(item => item.eyeColor != color);
        }
        else if (personManager.chosenPersonPlayer.eyeColor != color)
        {
            yesButton.interactable = false;
            noButton.interactable = true;
            computerPeople.RemoveAll(item => item.eyeColor == color);
        }

        if (color == "groene")
            guessedRedEyes = true;
        else if (color == "blauwe")
            guessedBlueEyes = true;
        else if (color == "zwarte")
            guessedBlackEyes = true;
    }
}
