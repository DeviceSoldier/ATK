using System.Collections;
using System.Collections.Generic;
using Nissensai2022.Runtime;
using UnityEngine;


public class PhaseManager : MonoBehaviour
{
    private StateMachine<GamePhase> _stateMachine = new StateMachine<GamePhase>();
    [SerializeField] private float phaseATime = 20f;
    [SerializeField] private float phaseBTime = 20f;
    [SerializeField] private float phaseCTime = 20f;

    private void Start()
    {
        _stateMachine.AddNode(GamePhase.A, () => { }, () =>
        {
            Debug.Log("Enter phase A");
            Timeline.RestartTimer();
        }, () => { Debug.Log("Leave phase A"); });

        _stateMachine.AddNode(GamePhase.B, () => { }, () =>
        {
            ResultRank result = ResultRank.A;
            Nissensai.SendResult(result);
            
            Debug.Log("Enter phase B");
            Timeline.ResetTimer();
        }, () => { Debug.Log("Leave phase B"); });

        _stateMachine.AddNode(GamePhase.C, () => { }, () =>
        {
            Debug.Log("Enter phase C");
            Timeline.ResetTimer();
        }, () => { Debug.Log("Leave phase C"); });

        _stateMachine.AddNode(GamePhase.Result, () => { }, () =>
        {
            Debug.Log("Enter phase Result");
            Timeline.StopTimer();
        }, () => { });

        _stateMachine.AddEdge(GamePhase.A, GamePhase.B, () => Timeline.CurrentTime > phaseATime);
        _stateMachine.AddEdge(GamePhase.B, GamePhase.C, () => Timeline.CurrentTime > phaseBTime);
        _stateMachine.AddEdge(GamePhase.C, GamePhase.Result, () => Timeline.CurrentTime > phaseCTime);
        
        _stateMachine.SetEntry(GamePhase.A);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}