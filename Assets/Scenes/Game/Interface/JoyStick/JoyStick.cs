using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image stick;
    public Vector2 inputVector;
    void Start()
    {
        stick = transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObject.GetComponent<Image>().rectTransform,eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / GetComponent<Image>().rectTransform.sizeDelta.x);
            pos.y = (pos.y / GetComponent<Image>().rectTransform.sizeDelta.y);
            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            stick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (GetComponent<Image>().rectTransform.sizeDelta.x / 2), inputVector.y * (GetComponent<Image>().rectTransform.sizeDelta.y / 2));
        }
        else
        {
            print(Mathf.Sqrt(Mathf.Pow(gameObject.GetComponent<Image>().rectTransform.rect.width / 2, 2) - Mathf.Pow(gameObject.GetComponent<Image>().rectTransform.position.y, 2)));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.rectTransform.position = gameObject.GetComponent<Image>().rectTransform.position;
        inputVector = new Vector2(0, 0);
    }
//    public void TrackTach()
//    {
//        if (Input.GetMouseButton(0))
//        {
//            Vector2 targerVector = new Vector2(Input.mousePosition.x - RectTransformUtility.WorldToScreenPoint(Camera.main, GetComponent<Image>().rectTransform.position).x, Input.mousePosition.y - RectTransformUtility.WorldToScreenPoint(Camera.main, GetComponent<Image>().rectTransform.position).y); ;
//            if(targerVector.magnitude < GetComponent<Image>().rectTransform.rect.width / 2)
//            {
//                stick.rectTransform.position = Input.mousePosition;
//                stick.rectTransform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, stick.rectTransform.position.z));
//                stick.rectTransform.position = new Vector3(stick.rectTransform.position.x, stick.rectTransform.position.y, 0);
//            }
//            else
//            {
//                //print("stick.rectTransform.position" + stick.rectTransform.position);
//                //Vector3 diraction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GetComponent<Image>().rectTransform.position;
//                //print(diraction.normalized);
//                //stick.rectTransform.position = GetComponent<Image>().rectTransform.position + ( diraction.normalized * 1);
//                //Vector2 position = new Vector2(Input.mousePosition.x * GetComponent<Image>().rectTransform.rect.width * 2) - GetComponent<Image>().rectTransform.rect.width, (Input.mousePosition.y * GetComponent<Image>().rectTransform.rect.height * 2) - GetComponent<Image>().rectTransform.rect.height);
//                //stick.rectTransform.position =
//            }
//        }
//        else
//        {
//            stick.transform.position = transform.position;
//        }
//    }
}
