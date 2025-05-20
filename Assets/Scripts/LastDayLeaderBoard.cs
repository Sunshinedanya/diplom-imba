using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;
public class LastDayLeaderBoard : MonoBehaviour
{
    [SerializeField] private List<Text> names;
    [SerializeField] private List<Text> times;
    
    [SerializeField] private InputField leaderboardName;
    [SerializeField] private Text leaderboardTime;
    
    private const string PUBLICKEY = "240fa9386cb69bac5a848fb8044f1c6f752e383c4c905dbaa66d130747e00365";

    private void Start()
    {
        GetLeaderboard();
        leaderboardTime.text = TimeToStringShort(Timer.Instance.currentTime);
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(PUBLICKEY, callback: (msg) =>
        {
            var loopLength =  msg.Length < names.Count ? msg.Length : names.Count;
            
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;

                var score = msg[i].Score;

                var dirtyTime = ScoreToTime(score);
                var cleanTime = TimeToStringShort(dirtyTime);
                
                times[i].text = cleanTime;
            }
        });
    }

    public void SetLeaderboard()
    {
        LeaderboardCreator.UploadNewEntry(PUBLICKEY, leaderboardName.text, TimeToScore(Timer.Instance.currentTime), ((_) =>
        {
            GetLeaderboard();
        }));
    }
    
    public static int TimeToScore(float timeInSeconds)
    {
        // Максимальное время (секунд), после которого баллы не начисляются
        const float maxTime = 600f; // 10 минут
        // Базовый множитель для создания достаточного диапазона значений
        const int baseMultiplier = 10000;
    
        // Если время превышает максимальное - возвращаем 0
        if(timeInSeconds > maxTime) return 0;
    
        // Инвертируем время: чем меньше время, тем больше баллов
        // Добавляем 1, чтобы избежать деления на 0
        float invertedTime = 1f / (timeInSeconds + 1f);
    
        // Масштабируем и округляем
        int score = (int)(invertedTime * baseMultiplier);
    
        return score;
    }
    
    public static float ScoreToTime(int score)
    {
        const int baseMultiplier = 10000;
    
        // Защита от деления на 0
        if(score <= 0) return float.MaxValue;
    
        // Обратное преобразование
        float invertedTime = (float)score / baseMultiplier;
        float timeInSeconds = (1f / invertedTime) - 1f;
    
        return timeInSeconds;
    }
    public static string TimeToStringShort(float timeInSeconds)
    {
        var timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
    }
    
}
