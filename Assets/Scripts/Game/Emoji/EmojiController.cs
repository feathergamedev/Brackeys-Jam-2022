using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEmojiType
{
    NONE = 0,
    GHOST = 1,
    SHINY_EYES = 2,
}

public class EmojiController : MonoBehaviour
{
    private const float EMOJI_TRANSITION_TIME = 0.2f;

    [Header("Components")]
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;

    private Coroutine emojiPerformCoroutine = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayEmoji(EEmojiType type)
    {
        if (emojiPerformCoroutine != null)
        {
            StopCoroutine(emojiPerformCoroutine);
            emojiPerformCoroutine = null;
        }

        var sprites = EmojiDataManager.Instance.GetEmojiSprites(type);
        _renderer.sprite = sprites[0];
        _animator.SetTrigger("NormalPerform");

        emojiPerformCoroutine = StartCoroutine(PerformEmojiSequence(sprites));
    }

    private IEnumerator PerformEmojiSequence(List<Sprite> sprites)
    {
        var spriteIndex = 0;

        while (true)
        {
            _renderer.sprite = sprites[spriteIndex];
            yield return new WaitForSeconds(EMOJI_TRANSITION_TIME);

            spriteIndex++;
            if (spriteIndex == sprites.Count)
                spriteIndex = 0;
        }
    }
}
