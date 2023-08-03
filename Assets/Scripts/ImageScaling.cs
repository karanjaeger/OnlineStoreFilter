using System.Drawing;
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
        mainBody.sizeDelta = new Vector2(1920, mainBody.sizeDelta.y);
        filterTab.GetComponent<RectTransform>().sizeDelta = new Vector2 (500, 1080);
        isOpen = false;
    }

    public void  ToggleFilterTab()
    {
        if(!isOpen)
        {
            ImageScale(1420, true);
        }
        else
        {
            ImageScale(1920, false);
        }   
    }

    private void ImageScale (float size, bool control)    {
        
        filterTab.SetActive(control);
        mainBody.sizeDelta = new Vector2(size, mainBody.sizeDelta.y);
        isOpen = control;
    }
}
