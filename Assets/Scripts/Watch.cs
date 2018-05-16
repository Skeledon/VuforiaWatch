using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Watch : MonoBehaviour
{

    public float TouchRescaleFactor = .0001f;
    public GameObject MyGUI;
    public Renderer MyRenderer;

    private float minSize = 4;
    // Update is called once per frame
    void Update ()
    {
        HandleInput();
        HandleUI();
    }

    private void HandleInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.parent.localScale += new Vector3(1, 1, 1) * TouchRescaleFactor * touchDeltaPosition.y;
            if (transform.parent.localScale.x < minSize)
                transform.parent.localScale = new Vector3(minSize, minSize, minSize);
        }

    }

    private void HandleUI()
    {
        MyGUI.SetActive(!MyRenderer.enabled);
    }

}
