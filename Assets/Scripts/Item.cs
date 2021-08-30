using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] ItemData data;

    public ItemData GetData()
    {
        return data;
    }
}
