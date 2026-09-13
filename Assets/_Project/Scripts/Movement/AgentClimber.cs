using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentClimber
{
    private readonly NavMeshAgent _agent;
    private readonly MonoBehaviour _coroutineRunner;

    private readonly float _speed;

    private Coroutine _climbProcess;

    public bool InProcess => _climbProcess != null;

    public AgentClimber(NavMeshAgent agent, MonoBehaviour coroutineRunner, float speed)
    {
        _agent = agent;
        _coroutineRunner = coroutineRunner;

        _speed = speed;
    }

    public void Climb(OffMeshLinkData linkData)
    {
        if (InProcess)
            return;

        _climbProcess = _coroutineRunner.StartCoroutine(ClimbProcess(linkData));
    }

    private IEnumerator ClimbProcess(OffMeshLinkData linkData)
    {
        Vector3 startPosition = linkData.startPos + Vector3.up * _agent.baseOffset;

        Vector3 endPosition = linkData.endPos + Vector3.up * _agent.baseOffset;

        float distance = Vector3.Distance(startPosition, endPosition);

        float duration = distance / _speed;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float progress = elapsedTime / duration;

            _agent.transform.position = Vector3.Lerp(startPosition, endPosition, progress);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _agent.transform.position = endPosition;

        _agent.CompleteOffMeshLink();

        _climbProcess = null;
    }
}