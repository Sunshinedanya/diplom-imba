using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool timerEnabled = true;

    public static Timer Instance;
    
    // Текущее время прохождения в секундах
    public float currentTime { private set; get; }
    private bool isTimerRunning = false;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        if (isTimerRunning && timerEnabled)
        {
            currentTime += Time.deltaTime;
            //UpdateTimerDisplay();
        }
    }

    // Запуск таймера
    public void StartTimer()
    {
        isTimerRunning = true;
        currentTime = 0f;
    }

    // Остановка таймера
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Получение текущего времени в секундах (int)
    public int GetCurrentTime()
    {
        return Mathf.FloorToInt(currentTime);
    }

    // Обновление отображения таймера
    // private void UpdateTimerDisplay()
    // {
    //     if (timerText != null)
    //     {
    //         int minutes = Mathf.FloorToInt(currentTime / 60f);
    //         int seconds = Mathf.FloorToInt(currentTime % 60f);
    //         timerText.text = $"{minutes:00}:{seconds:00}";
    //     }
    // }

    // Пример использования при завершении уровня
    public void OnLevelCompleted()
    {
        StopTimer();
        int finalTime = GetCurrentTime();
        
        // Сохраняем результат в лидерборд
        //Leaderboard.AddPlayerScore("PlayerName", finalTime);
        Debug.Log($"Level completed in: {FormatTime(finalTime)}");
    }

    public string GetFormattedTime()
    {
        return FormatTime(GetCurrentTime());
    }
    
    // Форматирование времени из int в строку
    private string FormatTime(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return $"{minutes:00}:{seconds:00}";
    }
}
