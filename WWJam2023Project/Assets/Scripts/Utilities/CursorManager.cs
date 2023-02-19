using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Transform _cursorTransform;
    float cursorWidth;
    float cursorHeight;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _cursorTransform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
    }
}