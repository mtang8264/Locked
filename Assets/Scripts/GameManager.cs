using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool doorUnlocked;
    public Transform door;
    public Vector3 doorPosition;
    public Vector3 doorRotation;

    [Header("Gearbox")]
    public TextMeshProUGUI gearText;
    public float secPerTextFade;
    public int gearInHand;
    public bool gearsDone;
    private bool gearsRead = false;

    [Header("Return")]
    public Collider doorBlock;
    public LookDialog[] gooseDialogs;
    public LookDialog bedDialog;
    public DoorClicker bedClick;
    public string postGearDialog;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void Update()
    {
        if(doorUnlocked)
        {
            door.position = doorPosition;
            door.localEulerAngles = doorRotation;
        }

        if(GearShaft.complete == 4)
        {
            gearsDone = true;
        }

        if(gearsDone && !gearsRead)
        {
            gearsRead = true;
            Gearbox.complete = true;
        }

        if(gearsDone)
        {
            doorBlock.enabled = false;
            foreach(LookDialog d in gooseDialogs)
            {
                d.text = postGearDialog;
            }
            bedDialog.text = "That was a weird dream...";
            bedClick.enabled = true;
        }
    }

    public static void PickUpGear(int i)
    {
        instance.gearInHand = i;
        instance.SendMessage("ShowGearText");
    }

    public void ShowGearText()
    {
        if(gearsDone == false)
            StartCoroutine(PickUpGearText());
    }
    public IEnumerator PickUpGearText()
    {
        StopCoroutine("CoPlaceGear");
        StopCoroutine("PickUpGearText");

        gearText.color = new Color(1, 1, 1, 0);
        gearText.text = "You picked up a ";
        switch(gearInHand)
        {
            case 1:
                gearText.text += "a small gear.";
                break;
            case 2:
                gearText.text += "a medium gear.";
                break;
            case 3:
                gearText.text += "a large gear.";
                break;
            default:
                gearText.text = "You don't know what you picked up.";
                break;
        }
        for (int i = 0; i < 60; i++)
        {
            gearText.color = new Color(1, 1, 1, gearText.color.a + (1f / 60f));
            yield return new WaitForSeconds(secPerTextFade / 60f);
        }
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 60; i++)
        {
            gearText.color = new Color(1, 1, 1, gearText.color.a - (1f / 60f));
            yield return new WaitForSeconds(secPerTextFade / 60f);
        }
    }

    public static void PlaceGear(GearShaft shaft)
    {
        if(instance.gearInHand == shaft.targetSize)
        {
            shaft.Place();
        }
        instance.SendMessage("PlaceGearText", shaft);
    }
    public void PlaceGearText(GearShaft shaft)
    {
        StartCoroutine(CoPlaceGear(gearInHand, shaft.targetSize));

        gearInHand = 0;
    }

    public IEnumerator CoPlaceGear(int k, int j)
    {
        StopCoroutine("CoPlaceGear");
        StopCoroutine("PickUpGearText");

        gearText.color = new Color(1, 1, 1, 0);
        if(k == j)
        {
            gearText.text = "The gear fit into place.";
        }
        else if(k == 0)
        {
            gearText.text = "You don't have a gear.";
        }
        else
        {
            gearText.text = "The gear broke as you tried to fit in on.";
        }

        for (int i = 0; i < 60; i++)
        {
            gearText.color = new Color(1, 1, 1, gearText.color.a + (1f / 60f));
            yield return new WaitForSeconds(secPerTextFade / 60f);
        }
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 60; i++)
        {
            gearText.color = new Color(1, 1, 1, gearText.color.a - (1f / 60f));
            yield return new WaitForSeconds(secPerTextFade / 60f);
        }
    }
}
