using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ConversationData", menuName = "ScriptableObject/Conversation", order = 0)]
[System.Serializable]
public class ConversationData : ScriptableObject
{
    public List<SentenceData> sentences;

    public bool hasDiverseOption;
    public string optionKey;
}
