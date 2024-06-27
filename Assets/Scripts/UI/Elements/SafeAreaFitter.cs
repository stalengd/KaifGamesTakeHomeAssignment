using UnityEngine;

namespace KaifGames.TestClicker.UI.Elements
{
    // Note that this does not work for editor window
    [RequireComponent(typeof(RectTransform))]
    public sealed class SafeAreaFitter : MonoBehaviour
    {
        private void OnEnable()
        {
            var area = Screen.safeArea;
            var screen = new Rect(0, 0, Screen.width, Screen.height);
            var transform = this.transform as RectTransform;

            area.xMin = Mathf.Clamp(area.xMin, 0, Screen.width);
            area.xMax = Mathf.Clamp(area.xMax, 0, Screen.width);
            area.yMin = Mathf.Clamp(area.yMin, 0, Screen.height);
            area.yMax = Mathf.Clamp(area.yMax, 0, Screen.height);

            var marginBottom = (area.yMin - screen.yMin) / screen.height;
            var marginTop = (screen.yMax - area.yMax) / screen.height;
            var marginLeft = (area.xMin - screen.xMin) / screen.width;
            var marginRight = (screen.xMax - area.xMax) / screen.width;

            transform.anchorMax = Vector2.one - new Vector2(marginRight, marginTop);
            transform.anchorMin = new Vector2(marginLeft, marginBottom);

            transform.sizeDelta = Vector2.zero;
            transform.anchoredPosition = Vector2.zero;
        }
    }
}
