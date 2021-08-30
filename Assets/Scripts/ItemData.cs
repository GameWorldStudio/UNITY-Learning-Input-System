using UnityEngine;
using static ETypeOfItem;

[CreateAssetMenu(fileName ="ItemData", menuName ="Items/ItemData")]
public class ItemData : ScriptableObject
{
    public TYPE_OF_ITEM TYPE_OF_ITEM;
    public Sprite itemSprite;
    public GameObject itemOnGround;
    public GameObject itemModel;
    public string nameItem;

}
