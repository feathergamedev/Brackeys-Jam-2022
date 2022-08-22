using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoSingleton<GameUIManager>
{
    [SerializeField] private UIDialogueBubble _dialogueBubble;

    private Canvas _mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        base.Init();

        _mainCanvas = GameObject.Find(UIConfig.MAIN_CANVAS_NAME).GetComponent<Canvas>();

        var dialogueBubblePrefab = Resources.Load<UIDialogueBubble>(DialogueConfig.DIALOGUE_RESOURCES_PATH + "UIDialogueBubble");
        _dialogueBubble = Instantiate(dialogueBubblePrefab, _mainCanvas.transform);

        _dialogueBubble.Init();
    }

    public void SetDialogueBubblePosition(GameObject target)
    {
        //TODO: Calculate position offset base on taget's size
        var offset = new Vector3(0, 1.5f, 0f);
        _dialogueBubble.SetPosition(target.transform.position + offset);
    }

    public void ShowDialogueBubble(SentenceData data)
    {
        _dialogueBubble.SetBubbleActive(true);
        _dialogueBubble.SetContent(data.speaker, data.words);
    }

    public void HideDialogueBubble()
    {
        _dialogueBubble.SetBubbleActive(false);
    }
}
