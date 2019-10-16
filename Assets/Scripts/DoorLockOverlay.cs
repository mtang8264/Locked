using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorLockOverlay : MonoBehaviour
{
    public PlayerControls player;
    public TextMeshProUGUI narration;
    public Image crosshair;
    public OverlayClickCallback background;

    public int[] current;
    public TextMeshProUGUI[] text;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        player.enabled = false;

        narration.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        player.enabled = false;

        narration.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(false);
    }

    void Update()
    {
        for(int i = 0; i < 4; i ++)
        {
            if(text[i].GetComponent<OverlayClickCallback>().down == true && text[i].GetComponent<OverlayClickCallback>().read == false)
            {
                text[i].GetComponent<OverlayClickCallback>().read = true;
                current[i]++;
                if(current[i] > 9)
                {
                    current[i] = 0;
                }
            }

            text[i].text = "" + current[i];
        }

        if(background.down && !background.read)
        {
            background.down = false;
            background.read = true;
            Cursor.lockState = CursorLockMode.Locked;
            player.enabled = true;
            narration.gameObject.SetActive(true);
            crosshair.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        if(current[0] == 4 && current[1] == 3 && current[2] == 1 && current[3] == 7)
        {
            Cursor.lockState = CursorLockMode.Locked;
            player.enabled = true;
            narration.gameObject.SetActive(true);
            crosshair.gameObject.SetActive(true);

            GameManager.instance.doorUnlocked = true;

            gameObject.SetActive(false);

            Destroy(this);
        }
    }
}
