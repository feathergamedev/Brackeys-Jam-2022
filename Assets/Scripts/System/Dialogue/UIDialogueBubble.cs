using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDialogueBubble : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private TMP_Text _wordText;
    [SerializeField] private TMP_Text _speakerNameText;

    public void Init()
    {
        SetBubbleActive(false);
    }

    public void SetBubbleActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void SetPosition(Vector3 position)
    {
        _rectTransform.position = position;
    }

    public void SetContent(ESpeaker speaker, string words)
    {
        _speakerNameText.text = speaker.ToString();
        _wordText.text = words;
    }
}
