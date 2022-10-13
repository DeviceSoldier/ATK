using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhaseManager : MonoBehaviour
{
    private StateMachine<GamePhase> _stateMachine = new StateMachine<GamePhase>();
    [SerializeField] private float phaseATime = 20f;
    [SerializeField] private float phaseBTime = 20f;
    [SerializeField] private float phaseCTime = 20f;

    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<PhaseA_TargetLook>().gameObject;
        
        _stateMachine.AddNode(GamePhase.A, () => { }, () =>
        {
            Debug.Log("Enter phase A");
            Timeline.RestartTimer();
        }, () =>
        {
            Debug.Log("Leave phase A"); 
            FindObjectOfType<Doragon_Move_A_Test>().enabled = false;
            FindObjectOfType<Doragon_Attack_A_Test>().enabled = false;
            FindObjectOfType<PhaseA_TargetLook>().enabled = false;
        });

        _stateMachine.AddNode(GamePhase.B, () => { }, () =>
        {
            Debug.Log("Enter phase B");
            Timeline.ResetTimer();
            _player.GetComponent<PlayerMove_1005>().enabled = true;
            _player.GetComponent<PhaseA_PhaseB>().enabled = true;
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