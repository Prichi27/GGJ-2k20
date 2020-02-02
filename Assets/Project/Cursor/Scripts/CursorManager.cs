using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    public Canvas parentCanvas;
    public RawImage mouseCursor;

    public Texture2D[] cursorTextures;

    public bool IsDragging { get; set; }
    public GameObject DragGameObject { get; set; }

    private void Start()
    {
        Cursor.visible = false;
    }


    private void Update()
    {
        if (!IsDragging)
            SetTextureLocation(Input.mousePosition);

        //else SetTextureLocation(DragGameObject.transform.position);
    }

    public void SwitchCursor(int index)
    {
        mouseCursor.texture = cursorTextures[index];
    }

    public void SetTextureLocation(Vector3 position)
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            position, parentCanvas.worldCamera,
            out movePos);

        Vector3 mousePos = parentCanvas.transform.TransformPoint(movePos);

        //Set fake mouse Cursor
        mouseCursor.transform.position = mousePos;

        //Move the Object/Panel
        transform.position = mousePos;
    }
}
