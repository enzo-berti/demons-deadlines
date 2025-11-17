using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class FastTyping : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI previewGo;
    [SerializeField] private TMP_InputField inputGo;

    private int score = 0;

    private void Update()
    {
        string cleanA = CleanText(previewGo.text);
        string cleanB = CleanText(inputGo.text);

        if (cleanA == cleanB)
        {
            score++;
        }
    }

    private string CleanText(string input)
    {
        if (input == null)
        {
            return string.Empty;
        }

        // Supprime les caractères invisibles : \u200B (zero width space), \uFEFF (BOM), etc.
        string cleaned = Regex.Replace(input, @"[\u200B-\u200D\uFEFF]", "");

        // Supprime les espaces multiples, retours à la ligne superflus, etc.
        cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();

        return cleaned;
    }
}
