using UnityEngine;
using UnityEngine.UI;

public class ImageScaling : MonoBehaviour
{
    [SerializeField] private RectTransform mainBody;
    [SerializeField] private GameObject filterTab;
    private bool isOpen;

    private void Start()
    {
        filterTab.SetActive(false);
        isOpen = false;
    }

    public void  ToggleFilterTab()
    {
        if(!isOpen)
        {
            ImageScale(1900, true);
        }
        else
        {
            ImageScale(2400, false);
        }
    }

    private void ImageScale (float size, bool control)
    {
        filterTab.SetActive(control);
        mainBody.sizeDelta = new Vector2(size, mainBody.sizeDelta.y);
        isOpen = control;
    }
}
