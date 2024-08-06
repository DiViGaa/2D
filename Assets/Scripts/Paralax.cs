using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Paralax : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f,1f)] float parallaxStrenght = 0.1f;
    [SerializeField] bool disableVerticalParallax;
    Vector3 targetPreviosPosition;

    private void Start()
    {
        if (!followingTarget)
        {
            followingTarget = Camera.main.transform;
        }
        targetPreviosPosition = followingTarget.position;
    }

    private void Update()
    {
        var delta = followingTarget.position - targetPreviosPosition;
        if (disableVerticalParallax)
        {
            delta.y = 0;
        }
        targetPreviosPosition = followingTarget.position;
        transform.position -= delta * parallaxStrenght;
    }
}
