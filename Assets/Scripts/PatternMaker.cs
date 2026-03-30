using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PatternMaker : MonoBehaviour
{
    public Image marker;
    public RectTransform center;
    public float radius = 100f;
    public float startAngleDegrees = 90f;
    public bool clockwise = true;

    public float bpm = 120f;
    public int beatsPerMeasure = 4;
    public int measuresPerRevolution = 1;
    public bool useUnscaledTime = true;

    public Image BG;

    float _t0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _t0 = Now();
    }

    // Update is called once per frame
    void Update()
    {
        if (!marker) return;

        var markerRt = marker.rectTransform;
        var centerRt = center ? center : (RectTransform)transform;

        float secondsPerRevolution = GetSecondsPerRevolution();
        if (secondsPerRevolution <= 0f) return;

        float elapsed = Now() - _t0;
        float phase01 = Mathf.Repeat(elapsed / secondsPerRevolution, 1f); // 0..1

        float angle = startAngleDegrees + (clockwise ? -1f : 1f) * (phase01 * 360f);
        float rad = angle * Mathf.Deg2Rad;

        Vector2 offset = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) * radius;
        markerRt.anchoredPosition = centerRt.anchoredPosition + offset;

        // Get KeyPress
        if (Input.GetKeyDown(KeyCode.Q)){
            if (marker.GetComponent<MarkerScript>().onBeat){
                Debug.Log("Bang");
                BG.color = new Color(0, 1, 0, 0.6f);
            } else {
                Debug.Log("Miss");
                BG.color = new Color(1, 0, 0, 0.6f);
            }
            StartCoroutine(ResetColor());
        }
    }

    public void Restart()
    {
        _t0 = Now();
    }

    float GetSecondsPerRevolution()
    {
        // beats per second = bpm / 60
        // beats in one revolution = beatsPerMeasure * measuresPerRevolution
        float beatsPerSecond = bpm / 60f;
        if (beatsPerSecond <= 0f) return 0f;

        float beats = Mathf.Max(1, beatsPerMeasure) * Mathf.Max(1, measuresPerRevolution);
        return beats / beatsPerSecond;
    }

    float Now() => useUnscaledTime ? Time.unscaledTime : Time.time;

    IEnumerator ResetColor(){
        yield return new WaitForSeconds(1f);
        BG.color = new Color(1f, 1f, 1f, .39f);
    }
}
