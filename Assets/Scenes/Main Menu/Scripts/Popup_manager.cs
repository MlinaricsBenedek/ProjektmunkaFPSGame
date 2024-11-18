using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_manager : MonoBehaviour
{
    public RectTransform rect;
    public float duration = 1f;
    public AnimationCurve animCurve;

    private void OnEnable()
    {
        StartCoroutine(ScaleCorotine(Vector3.zero, Vector3.one));
    }

    public void buttonPressWithDelay()
    {
        StartCoroutine(pressDelay());
    }    
    
    public void buttonPressNormal()
    {
        StartCoroutine(ScaleCorotine(Vector3.one, Vector3.zero));
    }

    private IEnumerator pressDelay()
    {
        yield return new WaitForSeconds(0.15f);
        StartCoroutine(ScaleCorotine(Vector3.one, Vector3.zero));
    }

    private IEnumerator ScaleCorotine(Vector3 _Start, Vector3 _End)
    {
        float time = 0;
        while (time <=duration)
        {
            time += Time.deltaTime;
            rect.localScale= Vector3.Lerp(_Start, _End, animCurve.Evaluate(time/duration));
            yield return null;
        }
        if (_Start == Vector3.one)
        {
            gameObject.SetActive(false);
        }
    }


}
