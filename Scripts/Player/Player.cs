using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float player_speed = 5f;
    public float max_player_health = 100f;
    public float player_health = 100f;


    public List<Item> inventory = new List<Item>();
    private int inHandItemIndex = -1;


    private Vector3 player_dir = Vector3.zero;

    private Rigidbody2D rigidbody;
    private Animator animator;

    [SerializeField] private ParticleSystem walking_particles;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        player_dir.x = Input.GetAxisRaw("Horizontal");
        player_dir.y = Input.GetAxisRaw("Vertical");

        UpdateAnimations();
        UpdateParticles();
        InventorySwitch();

        // Clear this this is only test for health bar :)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_health -= 10f;
        }
        UpdateUIHealth(max_player_health, player_health);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = player_dir.normalized * player_speed;
    }

    private void UpdateAnimations()
    {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float deltaX = pos.x - transform.position.x;
        if(deltaX >= 0) animator.SetFloat("Direction", 2);
        else animator.SetFloat("Direction", 4);

    }

    private void UpdateParticles()
    {
        
        if (player_dir.x == 0 && player_dir.y == 0) walking_particles.enableEmission = false;
        else walking_particles.enableEmission = true;

    }

    private void UpdateUIHealth(float max_health, float health)
    {
        //Default Max size is 300
        GameObject bar = GameObject.Find("UI_health_bar");
        float percentage = health / max_health;
        bar.transform.localScale = Vector3.Lerp(bar.transform.localScale, new Vector3(percentage * 300, bar.transform.localScale.y, bar.transform.localScale.z), 5f * Time.deltaTime);
    }


    private void InventorySwitch()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            int index = 0;
            if(inHandItemIndex != -1)
            {
                inventory[inHandItemIndex].itemState = States.ItemState.InInventory;
                GameObject.Find("player_inventory").transform.GetChild(inHandItemIndex).gameObject.SetActive(false);
            }

            inventory[index].itemState = States.ItemState.InHand;
            GameObject.Find("player_inventory").transform.GetChild(index).gameObject.SetActive(true);

            inHandItemIndex = index;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            int index = 1;

            if (inHandItemIndex != -1)
            {
                inventory[inHandItemIndex].itemState = States.ItemState.InInventory;
                GameObject.Find("player_inventory").transform.GetChild(inHandItemIndex).gameObject.SetActive(false);
            }

            inventory[index].itemState = States.ItemState.InHand;
            GameObject.Find("player_inventory").transform.GetChild(index).gameObject.SetActive(true);

            inHandItemIndex = index;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            int index = 2;

            if (inHandItemIndex != -1)
            {
                inventory[inHandItemIndex].itemState = States.ItemState.InInventory;
                GameObject.Find("player_inventory").transform.GetChild(inHandItemIndex).gameObject.SetActive(false);
            }

            inventory[index].itemState = States.ItemState.InHand;
            GameObject.Find("player_inventory").transform.GetChild(index).gameObject.SetActive(true);

            inHandItemIndex = index;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            int index = 3;

            if (inHandItemIndex != -1)
            {
                inventory[inHandItemIndex].itemState = States.ItemState.InInventory;
                GameObject.Find("player_inventory").transform.GetChild(inHandItemIndex).gameObject.SetActive(false);
            }

            inventory[index].itemState = States.ItemState.InHand;
            GameObject.Find("player_inventory").transform.GetChild(index).gameObject.SetActive(true);

            inHandItemIndex = index;
        }



    }

}
