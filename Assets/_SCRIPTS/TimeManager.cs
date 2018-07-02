using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = .05f;
    public float slowdownLength = 2f;

    void Slowmo()
    {
        Time.timeScale = slowdownFactor;
    }
}