using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Distance Settings")]
    public GameObject ball;
    Vector3 offset;

    [Space(2)]
    [Header("Color Change Settings")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Color[] colors;
    private int colorIndex;
    [SerializeField] private float lerpValue;

    [SerializeField] private float time;
    private float currentTime;


    void Start()
    {
        mainCamera = Camera.main;
        offset = transform.position - ball.transform.position;
    }

    void Update()
    {
        ChangeColor();
        ColorChangeTime();
    }

    void LateUpdate()
    {
        transform.position = ball.transform.position + offset;
    }


    private void ChangeColor()
    {
        mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, colors[colorIndex], lerpValue * Time.deltaTime);
    }

    private void ColorChangeTime()
    {
        if (currentTime <= 0)
        {
            IncreaseColorIndexValue();
            CheckColorIndexValue();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void IncreaseColorIndexValue()
    {
        colorIndex++;
    }
    private void CheckColorIndexValue()
    {
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }
    private void OnDestroy()
    {
        mainCamera.backgroundColor = colors[1];
    }

}