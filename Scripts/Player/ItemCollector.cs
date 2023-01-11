using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Item") collision.gameObject.GetComponent<Item>().isPickable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item") collision.gameObject.GetComponent<Item>().isPickable = false;
    }

    
}
