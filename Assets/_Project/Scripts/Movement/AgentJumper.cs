using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentJumper
{
    private readonly NavMeshAgent _agent;
    private readonly MonoBehaviour _coroutineRunner;

    private readonly float _speed;
    private readonly AnimationCurve _heightCurve;

    private Coroutine _jumpProcess;

    public bool InProcess => _jumpProcess != null;

    public AgentJumper(
        NavMeshAgent agent,
        MonoBehaviour coroutineRunner,
        float speed,
        AnimationCurve heightCurve)
    {
        _agent = agent;
        _coroutineRunner = coroutineRunner;
        _speed = speed;
        _heightCurve = heightCurve;
    }

    public void Jump(OffMeshLinkData linkData)
    {
        if (InProcess)
            return;

        _jumpProcess =
            _coroutineRunner.StartCoroutine(
                JumpProcess(linkData));
    }

    private IEnumerator JumpProcess(
        OffMeshLinkData linkData)
    {
        Vector3 startPosition =
            linkData.startPos +
            Vector3.up * _agent.baseOffset;

        Vector3 endPosition =
            linkData.endPos +
            Vector3.up * _agent.baseOffset;

        float distance =
            Vector3.Distance(
                startPosition,
                endPosition);

        float duration = distance / _speed;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float progress =
                elapsedTime / duration;

            Vector3 position =
                Vector3.Lerp(
                    startPosition,
                    endPosition,
                    progress);

            float yOffset =
                _heightCurve.Evaluate(progress);

            position.y += yOffset;

            _agent.transform.position = position;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _agent.transform.position =
            endPosition;

        _agent.CompleteOffMeshLink();

        _jumpProcess = null;
    }
}