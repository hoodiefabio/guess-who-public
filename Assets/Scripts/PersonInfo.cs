using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonInfo : MonoBehaviour
{
    [SerializeField] PersonManager manager;
    [SerializeField] GameObject winscreen;
    public bool availible;
    public bool computerPicture;
    public bool playerPicture;

    public bool old = false;
    public bool male = false;
    public bool glasses = false;
    public bool facialHair = false;
    public string eyeColor = "black";
    public string hairColor = "red";

    [SerializeField] public Image sprite;
    private Button personButton;

 
    void Start()
    {
        availible = true;
        personButton = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!availible)
        {
            personButton.image.color = Color.gray;
            sprite.color = Color.gray;
        }

        if (!manager.isGuessing)
        {
            personButton.interactable = false;
        }
        else if (manager.isGuessing)
        {
            personButton.interactable = true;
        }
    }

    public void CheckPerson()
    {
        if (manager.isGuessing && availible)
        {
            if (computerPicture)
            {
                winscreen.SetActive(true);
            }
            else
            {
                availible = false;
                manager.currentResponseImage.sprite = manager.noImage;
                manager.feedbackAnimation.Play(manager.animationName);
                manager.noFeedbackSound.PlayOneShot(manager.noFeedbackSound.clip);
            }
            manager.isGuessing = false;
            manager.guessText.enabled = false;
            manager.whosTurn *= -1;
        }
        manager.confirmBtn.interactable = false;
    }
}
