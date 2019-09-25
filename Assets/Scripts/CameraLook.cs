using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraLook : MonoBehaviour
{
    private Camera cam;

    public TMP_Text text;

    public string currentText;

    public float rayDistance;

    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        //Debug.DrawRay(ray.origin, ray.direction * rayDistance);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.GetComponent<LookDialog>() != null)
                currentText = hit.collider.GetComponent<LookDialog>().text;
            else
                currentText = "";
        }

        if(currentText.Length > text.text.Length)
        {
            text.text = currentText.Substring(0, text.text.Length+1);
        }
    }
}