using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SentenceData", menuName = "ScriptableObject/Sentence", order = 1)]
[System.Serializable]
public class SentenceData
{
    public ESpeaker speaker;

    [TextArea]
    public string words;
}
