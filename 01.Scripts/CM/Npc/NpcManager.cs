using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public static NpcManager Instance = null;
    public GameObject Npc;
    public GameObject fKey;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
