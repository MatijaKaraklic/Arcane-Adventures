using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static void UpdateUIAmmo(int ammo, int max_ammo)
    {
        GameObject.Find("UI_ammo").GetComponent<TMP_Text>().text = ammo + "/" + max_ammo;
    }

    public static void ShowPickUpInfo(bool active)
    {
        GameObject.Find("UI_pick_up").GetComponent<TMP_Text>().enabled = active;
    }


}
