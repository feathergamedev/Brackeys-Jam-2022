using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EmojiData
{
    public EEmojiType Type;
    public List<Sprite> Sprites;
}

[CreateAssetMenu(fileName = "New EmojiDataTable", menuName = "Emoji/EmojiDataTable", order = 1)]
public class EmojiDataTable : ScriptableObject
{
    public List<EmojiData> datas;
}
