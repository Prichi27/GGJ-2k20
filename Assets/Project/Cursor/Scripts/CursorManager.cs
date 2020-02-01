using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    public Canvas parentCanvas;
    public RawImage mouseCursor;

    public Texture2D[] cursorTextures;

    private void Start()
    {
        Cursor.visible = false;
    }


    private void Update()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);

        Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);

        //Set fake mouse Cursor
        mouseCursor.transform.position = mousePos;

        //Move the Object/Panel
        transform.position = mousePos;
    }

    public void SwitchCursor(int index)
    {
        mouseCursor.texture = cursorTextures[index];
    }
}
