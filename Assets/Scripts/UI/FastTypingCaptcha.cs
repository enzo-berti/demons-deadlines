using UnityEngine;

public class FastTypingCaptcha : MonoBehaviour
{
    [SerializeField] CaptchaGame captchaGame;

    [SerializeField] private float maxTimer = 20f;
    [SerializeField] private float minTimer = 10f;
    private float timer = 15f;

    private void Update()
    {
        if (PlayerData.Instance.DemonSummonedNum >= 2 && !captchaGame.IsActivated())
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                timer += Random.Range(minTimer, maxTimer);

                captchaGame.Activate();
            }
        }
    }
}
