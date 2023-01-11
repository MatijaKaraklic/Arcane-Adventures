using UnityEngine;

public class Item : MonoBehaviour
{

    public States.ItemState itemState { get; set; }
    public bool isPickable { get; set; }
    public bool isPointed { get; set; }


    private Material material;
    private SpriteRenderer sr;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        sr = GetComponent<SpriteRenderer>();

        itemState = States.ItemState.OnFloor;
        isPickable = false;
        isPointed = false;
    }

    public virtual void Update()
    {
        ITEM_ORIGINAL_Update();
    }

    private bool lastTimeStateUI = false;
    public void ITEM_ORIGINAL_Update()
    {

        if (isPickable && isPointed && itemState == States.ItemState.OnFloor)
        {
            material.SetFloat("_Outline_Size", 3);
            UIManager.ShowPickUpInfo(true);
        }
        else
        {
            material.SetFloat("_Outline_Size", 0);
            if(lastTimeStateUI) UIManager.ShowPickUpInfo(false);
        }


        if (isPickable && isPointed && Input.GetKeyDown(KeyCode.E) && itemState == States.ItemState.OnFloor) PickUp();

        if (itemState == States.ItemState.InHand) UpdateRotation();

        lastTimeStateUI = (isPickable && isPointed);
    }

    public void PickUp()
    {
        GameManager.instance.player.inventory.Add(this);
        itemState = States.ItemState.InInventory;
        transform.SetParent(GameObject.Find("player_inventory").transform);
        //transform.SetParent(GameManager.instance.player.transform.GetChild((int)States.PlayerChildren.Inventory));
        transform.localPosition = Vector2.zero;
        gameObject.SetActive(false);
        material.SetFloat("_Outline_Size", 0);
    }

    private void UpdateRotation()
    {
        float itemShift = 0.33f;

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float deltaX = pos.x - GameManager.instance.player.transform.position.x;
        float deltaY = pos.y - transform.position.y;
        float angle_RAD = Mathf.Rad2Deg * (Mathf.Atan(deltaY / deltaX));


        if (deltaX <= 0)
        {
            transform.eulerAngles = new Vector3(0, 180, -angle_RAD);
            transform.localPosition = new Vector3(-itemShift, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, angle_RAD);
            transform.localPosition = new Vector3(itemShift, 0, 0);
        }

    }



}
