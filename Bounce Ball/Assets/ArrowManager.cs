using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowManager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] GameObject Platform;
    [SerializeField] float Speed = 1.2f;
    [SerializeField] string ArrowDirection;
    bool ArrowSituation;

    public void OnPointerDown(PointerEventData eventData)
    {
        ArrowSituation = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ArrowSituation = false;
    }
    void Update()
    {
        if (ArrowSituation)
        {
            if (ArrowDirection=="Left")
            {
                Platform.transform.Rotate(60 * Time.deltaTime* Speed, 0, 0);
            }
            else
            {
                Platform.transform.Rotate(-60 * Time.deltaTime * Speed, 0, 0);
            }
        }
    }
}
