using UnityEngine;

public class FastTypingRandChar : MonoBehaviour
{
    [SerializeField] private string randCharList = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private FastTyping fastTyping;

    [SerializeField] private float maxTimer = 10f;
    [SerializeField] private float minTimer = 2f;
    private float timer = 0f;

    private void Awake()
    {
        fastTyping = GetComponent<FastTyping>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer <= 0f)
        {
            timer += Random.Range(minTimer, maxTimer);

            if (Random.Range(0, 2) == 0)
            {
                fastTyping.AddInput(randCharList[Random.Range(0, randCharList.Length)].ToString());
            }
            else
            {
                fastTyping.RemoveInput();
            }
        }
    }
}
