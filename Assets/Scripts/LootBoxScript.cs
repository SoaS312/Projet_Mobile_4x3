using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBoxScript : MonoBehaviour
{
    public int index;
    public string selectedLoot;
    public Text text;
    public List<string> Loot;

    public void TakeYourChance()
    {
        index = Random.Range(0, Loot.Count);
        selectedLoot = Loot[index];
        text.text = "Congrats! You've won : \n" + selectedLoot;
        AddToInventory();
    }

    private void AddToInventory()
    {
            if (selectedLoot.Contains("Driver")){
                UpgradeInventory.staticUpgradeInventory.commonDriverCard++;
            }
            if (selectedLoot.Contains("Cook"))
            {
                UpgradeInventory.staticUpgradeInventory.commonCookCard++;
            }
            if (selectedLoot.Contains("Seller"))
            {
                UpgradeInventory.staticUpgradeInventory.commonSellerCard++;
            }
            if (selectedLoot.Contains("Vigile"))
            {
                UpgradeInventory.staticUpgradeInventory.commonVigileCard++;
            }
            if (selectedLoot.Contains("Coursier"))
            {
                UpgradeInventory.staticUpgradeInventory.commonCoursierCard++;
            }
            if (selectedLoot.Contains("Helico"))
            {
                UpgradeInventory.staticUpgradeInventory.commonHelicoCard++;
            }
        }

    }
