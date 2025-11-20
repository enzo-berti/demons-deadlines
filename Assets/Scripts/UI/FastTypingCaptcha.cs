using UnityEngine;

public class FastTypingCaptcha : MonoBehaviour
{
    [SerializeField] CaptchaGame captchaGame;

    private float maxTimer = 25f;
    private float minTimer = 15f;
    private float timer = 25f;

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
