using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PhaseManager : MonoBehaviour
{
    public StateMachine<GamePhase> StateMachine { get; private set; } = new StateMachine<GamePhase>();
    [SerializeField] public float phaseATime = 20f;
    [SerializeField] public float phaseBTime = 20f;
    [SerializeField] public float phaseCTime = 20f;

    private GameObject _player;
    private GameObject _dragon;

    private void Start()
    {
        _player = FindObjectOfType<PhaseA_TargetLook>().gameObject;
        _dragon = FindObjectOfType<Doragon_Move_A_Test>().gameObject;

        StateMachine.AddNode(GamePhase.A, () => { }, () =>
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

        StateMachine.AddNode(GamePhase.B, () => { }, () =>
        {
            Debug.Log("Enter phase B");
            Timeline.ResetTimer();
            _player.GetComponent<PlayerMove_1005>().enabled = true;
            _player.GetComponent<PhaseA_PhaseB>().enabled = true;
            _dragon.GetComponent<BossBPosition>().enabled = true;
        }, () =>
        {
            Debug.Log("Leave phase B");
            _player.GetComponent<PhaseA_PhaseB>().enabled = false;
            _dragon.GetComponent<BossBPosition>().enabled = false;
            _player.GetComponent<PlayerMove_1005>().enabled = false;
        });

        StateMachine.AddNode(GamePhase.C, () => { }, () =>
        {
            Debug.Log("Enter phase C");
            Timeline.ResetTimer();
            _dragon.GetComponent<BossCPosition>().enabled = true;
        }, () =>
        {
            Debug.Log("Leave phase C");
            _dragon.GetComponent<BossCPosition>().enabled = false;
            _player.GetComponent<PlayerMove_1005>().enabled = false;
        });

        StateMachine.AddNode(GamePhase.Result, () => { }, () =>
        {
            Debug.Log("Enter phase Result");
            Timeline.StopTimer();
            var bossHp = FindObjectOfType<BossHP>();
            ResultHandler.Process(bossHp.Hp, bossHp.MaxHp, FindObjectOfType<PlayerGage>().gage.Value);

            // todo real result process
            Nissensai2022.Runtime.Nissensai.SendResult(ResultHandler.Rank);
        }, () => { });

        StateMachine.AddEdge(GamePhase.A, GamePhase.B, () => Timeline.CurrentTime > phaseATime);
        StateMachine.AddEdge(GamePhase.B, GamePhase.C, () => Timeline.CurrentTime > phaseBTime);
        StateMachine.AddEdge(GamePhase.C, GamePhase.Result, () => Timeline.CurrentTime > phaseCTime);

        StateMachine.SetEntry(GamePhase.A);
    }

    private void Update()
    {
        StateMachine.Update();
    }
}