using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorshClick : MonoBehaviour
{
    private MoldText moldText;

    private int addMoldClickCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        var text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        moldText = text.GetComponent<MoldText>();
    }

    // Update is called once per frame
    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase is TouchPhase.Began)
            {
                moldText.AddMold(addMoldClickCount);
            }
        }
    }
}
