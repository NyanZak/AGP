using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CursorChanger : MonoBehaviour
{
    public Texture2D noClickCursor, rightClickCursor, leftClickCursor;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(leftClickCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
        else if (Input.GetMouseButton(1))
        {
            Cursor.SetCursor(rightClickCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(noClickCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}