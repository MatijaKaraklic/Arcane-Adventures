using UnityEngine;

public class CursorManager : MonoBehaviour
{

    void Awake()
    {
        Cursor.visible = false;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == States.ITEM_TAG) collision.gameObject.GetComponent<Item>().isPointed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == States.ITEM_TAG) collision.gameObject.GetComponent<Item>().isPointed = false;
    }

}
