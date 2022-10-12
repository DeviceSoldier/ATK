using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PhaseManager : MonoBehaviour
{
    private StateMachine<GamePhase> _stateMachine = new StateMachine<GamePhase>();
    [SerializeField] private float phaseATime = 20f;
    [SerializeField] private float phaseBTime = 20f;
    [SerializeField] private float phaseCTime = 20f;
    
    private void Start()
    {
        _stateMachine.AddNode(GamePhase.A,()=>{},()=>{Timeline.RestartTimer();},()=>{});
        _stateMachine.AddNode(GamePhase.B,()=>{},()=>{Timeline.ResetTimer();},()=>{});
        _stateMachine.AddNode(GamePhase.C,()=>{},()=>{Timeline.ResetTimer();},()=>{});
        _stateMachine.AddNode(GamePhase.Result,()=>{},()=>{Timeline.StopTimer();},()=>{});
        
        _stateMachine.AddEdge(GamePhase.A,GamePhase.B,()=>Timeline.CurrentTime>phaseATime);
        _stateMachine.AddEdge(GamePhase.B,GamePhase.C,()=>Timeline.CurrentTime>phaseBTime);
        _stateMachine.AddEdge(GamePhase.C,GamePhase.Result,()=>Timeline.CurrentTime>phaseCTime);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
