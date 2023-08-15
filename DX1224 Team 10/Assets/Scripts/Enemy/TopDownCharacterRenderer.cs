using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterRenderer : MonoBehaviour
{
    public static readonly string[] idleDirections = { "Idle N", "Idle W", "Idle S", "Idle E" };
    public static readonly string[] walkDirections = { "Walk N", "Walk W", "Walk S", "Walk E" };
    public static readonly string[] attackDirections = { "Attack N", "Attack W", "Attack S", "Attack E" };

    Animator animator;
    int lastDirection;

    private void Awake()
    {
        // cache the animator component
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
