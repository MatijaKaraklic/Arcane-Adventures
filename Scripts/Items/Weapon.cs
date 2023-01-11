using UnityEngine;

public class Weapon : Item
{

    public Bullet bullet_prefab;
    public int max_ammo;
    public int ammo;

    public override void Update()
    {
        ITEM_ORIGINAL_Update();
        if (Input.GetMouseButtonDown(0) && itemState == States.ItemState.InHand) Fire();
        if (Input.GetKeyDown(KeyCode.R) && itemState == States.ItemState.InHand) Reload();
    }

    private void Fire()
    {
        if (ammo == 0) return;
        Bullet bullet = Instantiate(bullet_prefab, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
        bullet.Shoot(transform.GetChild(0).transform.up);
        ammo--;
        UIManager.UpdateUIAmmo(ammo, max_ammo);
    }

    private void Reload()
    {
        ammo = max_ammo;
        UIManager.UpdateUIAmmo(ammo, max_ammo);
    }

}
