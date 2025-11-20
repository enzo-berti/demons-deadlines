using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static public PlayerData Instance { get; private set; } = null;
    public int Score { get; set; } = 0;

    public int DemonSummonedNum { get; set; } = 0;

    private void Awake()
    {
        Instance = this;
    }
}
