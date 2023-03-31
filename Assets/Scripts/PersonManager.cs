using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonManager : MonoBehaviour
{
    public bool isGuessing;
    public int whosTurn;
    public PersonInfo[] people;
    [SerializeField] Image guessBtnImage;
    [SerializeField] public Text guessText;
    [SerializeField] public Image currentResponseImage;
    [SerializeField] public Button confirmBtn;
    [SerializeField] Image playerPerson;
    [SerializeField] GameObject cpuTurn;
    [SerializeField] public Sprite yesImage;
    [SerializeField] public Sprite noImage;
    [SerializeField] public Sprite turnImage;
    [SerializeField] public Animator feedbackAnimation;
    [SerializeField] AudioSource yesFeedbackSound;
    [SerializeField] public AudioSource noFeedbackSound;
    public string animationName = "FeedbackAnimation";
    private PersonInfo chosenPersonCPU;
    public bool startCPUTurn;
    private bool startPlayerTurn;
    private Color guessColor;
    public PersonInfo chosenPersonPlayer;
    // Start is called before the first frame update
    void Start()
    {
        isGuessing = false;
        startCPUTurn = false;
        startPlayerTurn = true;
        whosTurn = 1;
        guessColor = guessBtnImage.color;
        //computer's person set to random
        chosenPersonCPU = people[Random.Range(0, people.Length)];
        chosenPersonCPU.computerPicture = true;
        //players person set to random
        chosenPersonPlayer = people[Random.Range(0, people.Length)];
        chosenPersonPlayer.playerPicture = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerPerson.sprite = chosenPersonPlayer.sprite.sprite;
        if (isGuessing)
            guessBtnImage.color = Color.gray;
        else
        {
            guessBtnImage.color = guessColor;
            guessText.enabled = false;
        }
            

        if(whosTurn > 0 && !startPlayerTurn)
        {
            cpuTurn.SetActive(false);
            startPlayerTurn = true;
            StartCoroutine(PlayerTurn());
        }
        else if (whosTurn < 0 && !startCPUTurn)
        {
            StartCoroutine(ComputerTurn());
            startPlayerTurn = false;
            isGuessing = false;
            startCPUTurn = true;

        }
    }

    private IEnumerator PlayerTurn()
    {
        currentResponseImage.sprite = turnImage;
        feedbackAnimation.Play(animationName);
        yield return new WaitForSecondsRealtime(1.3f);
        startCPUTurn = false;
    }
    private IEnumerator ComputerTurn()
    {
        yield return new WaitForSecondsRealtime(2.2f);
        cpuTurn.SetActive(true);
    }

    public void ToggleGuessing()
    {
        if (!startCPUTurn)
        {
            if (!isGuessing)
            {
                isGuessing = true;
                guessText.enabled = true;
            }
            else
            {
                isGuessing = false;
                guessText.enabled = false;
            }
        }
        confirmBtn.interactable = false;
    }

    public void GuessOld()
    {
        if (chosenPersonCPU.old)
        {
            currentResponseImage.sprite = yesImage;
            feedbackAnimation.Play(animationName);
            yesFeedbackSound.PlayOneShot(yesFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (!person.old)
                    person.availible = false;
            }
        }
        else if (!chosenPersonCPU.old)
        {
            currentResponseImage.sprite = noImage;
            feedbackAnimation.Play(animationName);
            noFeedbackSound.PlayOneShot(noFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.old)
                    person.availible = false;
            }
        }
        whosTurn *= -1;
    }

    public void GuessMale()
    {
        if (chosenPersonCPU.male)
        {
            currentResponseImage.sprite = yesImage;
            feedbackAnimation.Play(animationName);
            yesFeedbackSound.PlayOneShot(yesFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (!person.male)
                    person.availible = false;
            }
        }
        else if (!chosenPersonCPU.male)
        {
            currentResponseImage.sprite = noImage;
            feedbackAnimation.Play(animationName);
            noFeedbackSound.PlayOneShot(noFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.male)
                    person.availible = false;
            }
        }
        whosTurn *= -1;
    }

    public void GuessGlasses()
    {
        if (chosenPersonCPU.glasses)
        {
            currentResponseImage.sprite = yesImage;
            feedbackAnimation.Play(animationName);
            yesFeedbackSound.PlayOneShot(yesFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (!person.glasses)
                    person.availible = false;
            }
        }
        else if (!chosenPersonCPU.glasses)
        {
            currentResponseImage.sprite = noImage;
            feedbackAnimation.Play(animationName);
            noFeedbackSound.PlayOneShot(noFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.glasses)
                    person.availible = false;
            }
        }
        whosTurn *= -1;
    }
    public void GuessFacialHair()
    {
        if (chosenPersonCPU.facialHair)
        {
            currentResponseImage.sprite = yesImage;
            feedbackAnimation.Play(animationName);
            yesFeedbackSound.PlayOneShot(yesFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (!person.facialHair)
                    person.availible = false;
            }
        }
        else if (!chosenPersonCPU.facialHair)
        {
            currentResponseImage.sprite = noImage;
            feedbackAnimation.Play(animationName);
            noFeedbackSound.PlayOneShot(noFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.facialHair)
                    person.availible = false;
            }
        }
        whosTurn *= -1;
    }

    public void GuessHairColor(string guessColor)
    {
        if (chosenPersonCPU.hairColor == guessColor)
        {
            currentResponseImage.sprite = yesImage;
            feedbackAnimation.Play(animationName);
            yesFeedbackSound.PlayOneShot(yesFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.hairColor != guessColor)
                    person.availible = false;
            }
        }
        else if (chosenPersonCPU.hairColor != guessColor)
        {
            currentResponseImage.sprite = noImage;
            feedbackAnimation.Play(animationName);
            noFeedbackSound.PlayOneShot(noFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.hairColor == guessColor)
                    person.availible = false;
            }
        }
        whosTurn *= -1;
    }

    public void GuessEyeColor(string guessColor)
    {
        if (chosenPersonCPU.eyeColor == guessColor)
        {
            currentResponseImage.sprite = yesImage;
            feedbackAnimation.Play(animationName);
            yesFeedbackSound.PlayOneShot(yesFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.eyeColor != guessColor)
                    person.availible = false;
            }
        }
        else if (chosenPersonCPU.eyeColor != guessColor)
        {
            currentResponseImage.sprite = noImage;
            feedbackAnimation.Play(animationName);
            noFeedbackSound.PlayOneShot(noFeedbackSound.clip);
            foreach (PersonInfo person in people)
            {
                if (person.eyeColor == guessColor)
                    person.availible = false;
            }
        }
        whosTurn *= -1;
    } 
}
