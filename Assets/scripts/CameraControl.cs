using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public Sprite cursorNormal, cursorMove;
    public RectTransform _cursor;
    public float sensitivity = 10;
    public float speed = 3;

    private Image img;
    private Vector3 offset, direction;
    private Sprite current;

    void Start()
    {
        img = _cursor.GetComponent<Image>();
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        direction = Vector3.zero;

        if (CheckMouse())
        {
            current = cursorMove;
        }
        else
        {
            offset = new Vector3(_cursor.sizeDelta.x / 2, -_cursor.sizeDelta.y / 2, 0);
            current = cursorNormal;
        }

        _cursor.anchoredPosition = Input.mousePosition + offset;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _cursor.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0;
        transform.Translate(direction * speed * Time.deltaTime);
        img.sprite = current;
    }

    bool CheckMouse()
    {
        bool left = false, right = false, down = false, up = false;

        if (Input.mousePosition.x < sensitivity)
        {
            offset = new Vector3(_cursor.sizeDelta.x / 2, 0, 0);
            direction = Vector3.left;
            left = true;
        }

        if (Input.mousePosition.x > Screen.width - sensitivity)
        {
            offset = new Vector3(-_cursor.sizeDelta.x / 2, 0, 0);
            direction = Vector3.right;
            right = true;
        }

        if (Input.mousePosition.y < sensitivity)
        {
            offset = new Vector3(0, _cursor.sizeDelta.y / 2, 0);
            direction = Vector3.down;
            down = true;
        }

        if (Input.mousePosition.y > Screen.height - sensitivity)
        {
            offset = new Vector3(0, -_cursor.sizeDelta.y / 2, 0);
            direction = Vector3.up;
            up = true;
        }

        if (left && up)
        {
            offset = new Vector3(_cursor.sizeDelta.x / 2, -_cursor.sizeDelta.y / 2, 0);
            direction = new Vector3(-1, 1, 0);
            return true;
        }
        else if (left && down)
        {
            offset = new Vector3(_cursor.sizeDelta.x / 2, _cursor.sizeDelta.y / 2, 0);
            direction = new Vector3(-1, -1, 0);
            return true;
        }
        else if (right && down)
        {
            offset = new Vector3(-_cursor.sizeDelta.x / 2, _cursor.sizeDelta.y / 2, 0);
            direction = new Vector3(1, -1, 0);
            return true;
        }
        else if (right && up)
        {
            offset = new Vector3(-_cursor.sizeDelta.x / 2, -_cursor.sizeDelta.y / 2, 0);
            direction = new Vector3(1, 1, 0);
            return true;
        }

        if (left || up || right || down) return true;

        return false;
    }
}