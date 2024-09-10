using TMPro;
using UnityEngine;

namespace ScoreLogic
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreText : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;
        
        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }
        
        public void SetScore(int score)
        {
            if (score < 10)
            {
                _textMesh.text = $"0{score}";
            }
            else
            {
                _textMesh.text = score.ToString();
            }
        }
    }
}