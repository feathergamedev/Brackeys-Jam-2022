using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiDataManager : MonoSingleton<EmojiDataManager>
{
    private EmojiDataTable _dataTable;
    private Dictionary<EEmojiType, List<Sprite>> _emojiDataDic;

    public override void Init()
    {
        _emojiDataDic = new Dictionary<EEmojiType, List<Sprite>>();
        _dataTable = Resources.Load<EmojiDataTable>("Emoji/EmojiDataTable");

        foreach (var d in _dataTable.datas)
        {
            _emojiDataDic.Add(d.Type, d.Sprites);
        }
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Sprite> GetEmojiSprites(EEmojiType type)
    {
        if (_emojiDataDic.ContainsKey(type) == false)
        {
            Debug.LogError("沒有此Emoji資料。");
        }

        return _emojiDataDic[type];
    }
}
