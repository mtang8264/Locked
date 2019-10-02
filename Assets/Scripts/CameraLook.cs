using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraLook : MonoBehaviour
{
    public bool debug;

    public enum State
    {
        BLANK,
        TYPING,
        DONE,
        UNTYPING
    }

    public State state = State.BLANK;

    private Camera cam;

    public TMP_Text text;

    public string currentText;
    public string currentGoalText;
    public string goalText;

    public float rayDistance;

    public float secondsPerChar;
    public int charPerDelete;
    public float timer;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        CheckRaycast();

        CheckTextState();

        DrawText();
    }

    void CheckRaycast()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if(debug)
            Debug.DrawRay(ray.origin, ray.direction * rayDistance);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.GetComponent<LookDialog>() != null)
                goalText = hit.collider.GetComponent<LookDialog>().text;
            else
                goalText = "";
        }
        else
        {
            goalText = "";
        }
    }

    void CheckTextState()
    {
        if (goalText == "" && currentText == "")
        {
            state = State.BLANK;
        }
        else if (state == State.BLANK && goalText != "")
        {
            currentGoalText = goalText;
            state = State.TYPING;
        }
        else if (currentGoalText != goalText)
        {
            currentGoalText = "";
            state = State.UNTYPING;
        }
        else if (currentText == currentGoalText)
        {
            state = State.DONE;
        }
    }

    void DrawText()
    {
        switch(state)
        {
            case State.BLANK:
                timer = 0;
                break;
            case State.TYPING:
                timer += Time.deltaTime;
                if (timer > secondsPerChar)
                {
                    timer = 0;
                    currentText = currentGoalText.Substring(0, currentText.Length + 1);
                    while(currentText[currentText.Length-1] == ' ')
                    {
                        currentText = currentGoalText.Substring(0, currentText.Length + 1);
                    }
                }
                break;
            case State.DONE:
                timer = 0;
                break;
            case State.UNTYPING:
                timer += Time.deltaTime;
                if(timer > secondsPerChar)
                {
                    timer = 0;
                    for (int i = 0; i < charPerDelete; i++)
                    {
                        if (currentText != "")
                            currentText = currentText.Substring(0, currentText.Length - 1);
                    }
                }
                break;
        }

        text.text = currentText;
    }
}