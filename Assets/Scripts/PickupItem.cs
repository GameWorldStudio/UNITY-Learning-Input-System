using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryManager))]
public class PickupItem : MonoBehaviour
{
    private InventoryManager InventoryManager;

    private void Awake()
    {
        InventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ItemData itemData = other.GetComponent<Item>().GetData();

            bool canTake = InventoryManager.VerifyInvent(itemData);

            if (canTake)
            {
                SlotItem place = InventoryManager.placeHolderItem.Find(x => !x.isOccuped && x.TypeHolder == itemData.TYPE_OF_ITEM);

                InventoryManager.ItemTook(other.GetComponent<Item>(), place);

                Destroy(other.gameObject);
            }
            else
            {
                if (InventoryManager.GetCurrentSlotSelected().TypeHolder == itemData.TYPE_OF_ITEM)
                {
                    InventoryManager.tradeText.SetActive(true);
                    InventoryManager.SetTradeStatus(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Item newItem = other.GetComponent<Item>();
                       
                        Transform itemGroundPosition = other.transform;
                        Instantiate(InventoryManager.GetCurrentSlotSelected().GetItem().GetData().itemOnGround, itemGroundPosition);

                        InventoryManager.ItemTook(newItem, InventoryManager.GetCurrentSlotSelected());
                    }
                }
            }
        }
    }

}
