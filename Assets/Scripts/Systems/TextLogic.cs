using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class TextLogic : MonoBehaviour
{
    [SerializeField] TMP_InputField textA;
    [SerializeField] TMP_InputField textB;

    [SerializeField] TMP_Text scoreText;
    int score = 0;

    int indexText = 0;
    [SerializeField] List<string> listText;

    [SerializeField] AudioSource mailSend;

    private void Awake()
    {
        textB.text = listText[0];
    }

    void Update()
    {
        string cleanA = CleanText(textA.text);
        string cleanB = CleanText(textB.text);

        if (cleanA == cleanB)
        {
            score++;
            scoreText.text = "Point : " + score.ToString();

            textA.text = "";
            textB.text = listText[indexText++];
            mailSend.Play();
        }
    }

    private string CleanText(string input)
    {
        if (input == null) return string.Empty;

        // Supprime les caractères invisibles : \u200B (zero width space), \uFEFF (BOM), etc.
        string cleaned = Regex.Replace(input, @"[\u200B-\u200D\uFEFF]", "");

        // Supprime les espaces multiples, retours à la ligne superflus, etc.
        cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();

        return cleaned;
    }
}
