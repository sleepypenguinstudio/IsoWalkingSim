using UnityEngine;
using DG.Tweening;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Transform[] targetPositions;
    [SerializeField] private float flySpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;

    private int currentPositionIndex = 0;

    private void Start()
    {
        MoveToNextPosition();
    }

    private void MoveToNextPosition()
    {
        currentPositionIndex++;

        if (currentPositionIndex >= targetPositions.Length)
        {
            currentPositionIndex = 0;
        }

        Vector3 nextPosition = targetPositions[currentPositionIndex].position;

        transform.DOMove(nextPosition, flySpeed).SetEase(Ease.Linear).OnComplete(() =>
        {
            // Rotate towards the next position when the bird reaches the current position
            Vector3 nextDirection = targetPositions[(currentPositionIndex + 1) % targetPositions.Length].position - transform.position;
            transform.DOLookAt(transform.position + nextDirection, rotationSpeed, AxisConstraint.Y);
            MoveToNextPosition();
        });
    }
}
