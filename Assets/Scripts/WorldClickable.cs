using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldClickable : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Click()
    {
        canvasGroup.gameObject.SetActive(true);
    }
}
