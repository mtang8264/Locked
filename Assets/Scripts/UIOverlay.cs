using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIOverlay : MonoBehaviour
{
    public PlayerControls player;
    public TextMeshProUGUI text;
    public Image crosshair;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
        player.enabled = false;

        text.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            player.enabled = true;
            text.gameObject.SetActive(true);
            crosshair.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
