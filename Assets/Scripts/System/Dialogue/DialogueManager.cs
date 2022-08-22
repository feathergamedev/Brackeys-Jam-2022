using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    private bool isInDialogue = false;
    private bool isWaitingInput = false;
    private bool canMoveOn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaitingInput)
        {
            if (Input.inputString.Length > 0)
            {
                Debug.Log(Input.inputString);

                if (Input.inputString[0] >= 'A' && Input.inputString[0] <= 'z')
                {
                    canMoveOn = true;
                }
            }
        }
    }

    public void Test()
    {
        if (isInDialogue)
            return;

        var conversationKey = "Test";
        var conversationData = Resources.Load<ConversationData>(DialogueConfig.DIALOGUE_CONVERSATION_PREFIX + conversationKey);
        StartConversation(conversationData);
    }

    public void StartConversation(ConversationData data)
    {
        isInDialogue = true;
        StartCoroutine(ConversationSequence(data));
    }

    private IEnumerator ConversationSequence(ConversationData data)
    {
        var sentences = data.sentences;
        var totalSentenceCount = sentences.Count;
        var currentSentenceIndex = 0;

        while (currentSentenceIndex < totalSentenceCount)
        {
            canMoveOn = false;
            isWaitingInput = false;
            var currentSentence = sentences[currentSentenceIndex];
            Debug.LogFormat("{0}: {1}", currentSentence.speaker, currentSentence.words);

            var speakerWorldPos = GameObject.FindGameObjectsWithTag(currentSentence.speaker.ToString())[0];
            GameUIManager.Instance.SetDialogueBubblePosition(speakerWorldPos);
            GameUIManager.Instance.ShowDialogueBubble(currentSentence);

            //TODO: Text animation

            //Waiting input to end current sentence.
            isWaitingInput = true;
            yield return new WaitUntil(() => { return canMoveOn; });
            isWaitingInput = false;
            currentSentenceIndex++;
        }

        isInDialogue = false;
        GameUIManager.Instance.HideDialogueBubble();


        yield break;
    }
}
