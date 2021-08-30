using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    [SerializeField] Image imageHolder;
    public ETypeOfItem.TYPE_OF_ITEM TypeHolder;

    public bool isSelected = false;
    public bool isOccuped = false;

    Item item;

    Sprite itemSprite;
    string itemName;
    GameObject itemModel;
    GameObject itemInGame;

    private void Awake()
    {
        imageHolder = transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        UpdateProperties(item.GetData());
        isOccuped = true;
    }

    public void UpdateProperties(ItemData item)
    {
        itemSprite = item.itemSprite;
        itemName = item.nameItem;
        itemModel = item.itemModel;

        imageHolder.sprite = itemSprite;
        imageHolder.gameObject.GetComponent<CanvasGroup>().alpha = 1;

        //Créer le go chez le joueur
        CreateGameObject();

        if (isSelected)
        {
            if(TypeHolder != ETypeOfItem.TYPE_OF_ITEM.LIGHT)
            {
                itemInGame.SetActive(true);
            }
        }
    }

    public void CreateGameObject()
    {
        itemInGame = GameObject.Instantiate(itemModel, InventoryManager.hand);
        itemInGame.SetActive(false);
    }

    public Item GetItem()
    {
        return item;
    }

    public void Selected()
    {
        isSelected = true;

        GetComponent<Animator>().SetBool("IsSelected", true);

        if (itemInGame != null)
        {
            itemInGame.SetActive(true);
        }

    }

    public void Deselected()
    {
        Debug.Log(gameObject.name);
        isSelected = false;
        GetComponent<Animator>().SetBool("IsSelected", false);
        if (itemInGame != null)
        {
            itemInGame.SetActive(false);
        }
    
    }
}
