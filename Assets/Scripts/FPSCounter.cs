using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public float fpsCount;
    public Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateFPS", 1, 1);
    }

    void UpdateFPS()
    {
        fpsCount = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = "FPS: " + fpsCount;
    }
}
