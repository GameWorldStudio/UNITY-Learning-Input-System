using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ETypeOfItem;

public class InventoryManager : MonoBehaviour
{

    public List<SlotItem> placeHolderItem;

    public static Transform hand;

    private SlotItem currentSlotSelected;

    private bool isHide = false;
    private bool canTrade = false;

    private GameObject inventoryPanel;

    public GameObject tradeText;

    private void Awake()
    {
        placeHolderItem = FindObjectsOfType<SlotItem>().ToList();
        inventoryPanel = GameObject.FindGameObjectWithTag("Inventory");
        hand = GameObject.FindGameObjectWithTag("LeftHand").transform;
        placeHolderItem[0].Selected();
        currentSlotSelected = placeHolderItem.Find(x => x.isSelected);
    }

    public SlotItem GetCurrentSlotSelected()
    {
        return currentSlotSelected;
    }

    public bool GetTradeStatus()
    {
        return canTrade;
    }

    public void SetTradeStatus(bool tradeStatus)
    {
        canTrade = tradeStatus;
    }

    public void ChangeHideStatus()
    {
        Debug.Log("here");
        isHide = !isHide;
        inventoryPanel.GetComponent<Animator>().SetBool("IsHide", isHide);
    }

    void ChangeSlotItem(SlotItem selectedSlot)
    {
        if(selectedSlot != currentSlotSelected)
        {
            currentSlotSelected.Deselected();
            selectedSlot.Selected();
            currentSlotSelected = selectedSlot;
        }
    }

    public void ItemTook(Item item, SlotItem placeHolderInventory)
    {
        placeHolderInventory.SetItem(item);
    }

    public bool VerifyInvent(ItemData data)
    {
        TYPE_OF_ITEM type = data.TYPE_OF_ITEM;

        bool isGood = false;

        List<SlotItem> allHolderOfType = placeHolderItem.FindAll(x => x.TypeHolder == type);

        if(allHolderOfType.Count > 0)
        {
            for(int i = 0; i < allHolderOfType.Count && !isGood; i++)
            {
                if (!allHolderOfType[i].isOccuped)
                {
                    isGood = true;
                }
            }
        }
        else
        {
            throw new System.Exception("Aucune référence n'a été trouvée suite à cette recherche.\n\n\n Class:InventoryManager,Methode:VerifyInvent,Ligne41");
        }

        return isGood;
    }
}
