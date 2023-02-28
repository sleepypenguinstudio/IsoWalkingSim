using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using Cinemachine;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
 

    public Animator dialoganimator;


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; } //use to freeze player when dialogue is playing

    public static DialogueManager instance;


    public GameObject Player;
    bool isChoosing=false;

    CinemachineVirtualCamera dialogueCineMachineCamera;
    QuestGiver currentQuest;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        


    }


    private void Start()
    {
        dialogueIsPlaying = false;
        //dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    private void Update()
    {
        // return right away if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0) && !isChoosing)
        {

            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, CinemachineVirtualCamera cineMachineCamera,QuestGiver questGiver)
    {

        SetQuestProperty(cineMachineCamera,questGiver);

        Player.GetComponent<PlayerInputSystem>().enabled = false;
        Debug.Log("yes");

        dialoganimator.SetBool("isOpen", true);

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        // dialoguePanel.SetActive(true);

        ContinueStory();
       

    }


    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0);

        dialogueIsPlaying = false;
        // dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dialoganimator.SetBool("isOpen", false);

        Player.GetComponent<PlayerInputSystem>().enabled = true;

        if (!Quest_Class.instance.isQuestActive)
        {
            StartQuestProperty();
            Quest_Class.instance.currentState = Quest_Class.QuestState.AmidQuest;
            Quest_Class.instance.isQuestActive = true;
        }
        else
        {
            StartQuestProperty();
        }
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            DisplayChoices();

        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {

       
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        if (currentChoices.Count>0)
        {
            isChoosing = true;

        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

       // StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();


        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        isChoosing = false;
       
        ContinueStory();
    }
     public void SetQuestProperty(CinemachineVirtualCamera cineMachineCamera, QuestGiver questGiver)
    {
        dialogueCineMachineCamera = cineMachineCamera;

       

        currentQuest = questGiver;

    }

    public void StartQuestProperty()
    {


          dialogueCineMachineCamera.Priority = 8;


        if (!Quest_Class.instance.isQuestActive)
        {
            currentQuest.GiveQuest();
        }
       

        

           
        
       
    }
}
