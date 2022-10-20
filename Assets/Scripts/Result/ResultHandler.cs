using System.Collections;
using System.Collections.Generic;
using Nissensai2022.Runtime;
using UnityEngine;

public class ResultHandler
{
    public static bool IsReady { get; private set; } = false;
    
    public static ResultRank Rank { get; private set; } = ResultRank.E;
    public static float Result { get; private set; } = 0.0f;
    public static float Percentage { get; private set; } = 0.0f;

    public static ResultRank Process(float damage, float max, float multiplier)
    {
        Result = damage * multiplier;
        Percentage = Result / max;
        if (Percentage >= 1.0f)
            Rank = ResultRank.A;
        else if (Percentage >= 0.8f)
            Rank = ResultRank.B;
        else if (Percentage >= 0.6f)
            Rank = ResultRank.C;
        else if (Percentage >= 0.4f)
            Rank = ResultRank.D;
        else
            Rank = ResultRank.E;
        IsReady = true;
        return Rank;
    }

    public static void SendToServer()
    {
        if (!IsReady)
            return;
        Nissensai.SendResult(Rank);
        IsReady = false;
    }
}