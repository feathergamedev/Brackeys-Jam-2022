using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public static Tester instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            AudioManager.Instance.PlaySound(ESoundType.CLICK_BUTTON);

        if (Input.GetKeyDown(KeyCode.W))
            AudioManager.Instance.PlaySound(ESoundType.BOMB_EXPLODE);

        if (Input.GetKeyDown(KeyCode.E))
            AudioManager.Instance.PlaySound(ESoundType.GET_SCORE);
    }
}
