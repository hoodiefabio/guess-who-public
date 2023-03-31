using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionButtonBehaviour : MonoBehaviour
{
    [SerializeField] PersonManager personManager;
    [SerializeField] Button confirmBtn;
    [SerializeField] Animator guessAnimator;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] Text questionText;
    public string confirmAnimation = "ConfirmFeedback";
    public string selectedQuestion;
    private Color questionStartColor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        confirmBtn.interactable = false;
        questionStartColor = questionText.color;
    }

    private void Update()
    {
        if (!confirmBtn.interactable)
        {
            guessAnimator.Play("Idle");
            questionText.text = "Druk op een knop om een vraag te stellen";
            questionText.color = Color.grey;
        }
    }

    public void ConfirmQuestion()
    {
        if (selectedQuestion == "old")
            personManager.GuessOld();
        else if (selectedQuestion == "male")
            personManager.GuessMale();
        else if (selectedQuestion == "glasses")
            personManager.GuessGlasses();
        else if (selectedQuestion == "facialHair")
            personManager.GuessFacialHair();

        else if (selectedQuestion == "redHair")
            personManager.GuessHairColor("grijs");
        else if (selectedQuestion == "blueHair")
            personManager.GuessHairColor("blond");
        else if (selectedQuestion == "blackHair")
            personManager.GuessHairColor("bruin");

        else if (selectedQuestion == "redEyes")
            personManager.GuessEyeColor("groene");
        else if (selectedQuestion == "blueEyes")
            personManager.GuessEyeColor("blauwe");
        else if (selectedQuestion == "blackEyes")
            personManager.GuessEyeColor("zwarte");

        selectedQuestion = null;
        questionText.text = "Druk op een knop om een vraag te stellen";
        questionText.color = Color.grey;
        confirmBtn.interactable = false;
    }

    private void ButtonPress()
    {
        confirmBtn.interactable = true;
        personManager.isGuessing = false;
        guessAnimator.Play(confirmAnimation);
        buttonSound.PlayOneShot(buttonSound.clip);
        questionText.color = questionStartColor;
    }

    public void SelectOld()
    {
        if (!personManager.startCPUTurn)
        {
            questionText.text = "Is de persoon oud?";
            selectedQuestion = "old";
            ButtonPress();
        }
    }

    public void SelectMale()
    {
        if (!personManager.startCPUTurn)
        {
            questionText.text = "Is de persoon een man?";
            selectedQuestion = "male";
            ButtonPress();
        }
    }

    public void SelectGlasses()
    {
        if (!personManager.startCPUTurn)
        {
            questionText.text = "Heeft de persoon een bril?";
            selectedQuestion = "glasses";
            ButtonPress();
        }
    }

    public void SelectFacialHair()
    {
        if (!personManager.startCPUTurn)
        {
            questionText.text = "Heeft de persoon gezichtsbeharing?";
            selectedQuestion = "facialHair";
            ButtonPress();
        }
    }

    public void SelectHairColor(string color)
    {
        if (!personManager.startCPUTurn)
        {
            if (color == "grijs")
            {
                questionText.text = "Heeft de persoon grijs haar?";
                selectedQuestion = "redHair";
            }
            else if (color == "blond")
            {
                questionText.text = "Heeft de persoon blond haar?";
                selectedQuestion = "blueHair";
            }
            else if (color == "bruin")
            {
                questionText.text = "Heeft de persoon bruin haar?";
                selectedQuestion = "blackHair";
            }
            ButtonPress();
        }
    }

    public void SelectEyeColor(string color)
    {
        if (!personManager.startCPUTurn)
        {
            if (color == "groene")
            {
                questionText.text = "Heeft de persoon groene ogen?";
                selectedQuestion = "redEyes";
            }
            else if (color == "blauwe")
            {
                questionText.text = "Heeft de persoon blauwe ogen?";
                selectedQuestion = "blueEyes";
            }
            else if (color == "zwarte")
            {
                questionText.text = "Heeft de persoon zwarte ogen?";
                selectedQuestion = "blackEyes";
            }
            ButtonPress();
        }
    }

}
