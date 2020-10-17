using UnityEngine;
using Cinemachine;
public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public Transform FollowTarget;
    private CinemachineVirtualCamera vcam;

    // Use this for initialization
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
            if (Player != null)
            {
                FollowTarget = Player.transform;
                vcam.LookAt = FollowTarget;
                vcam.Follow = FollowTarget;
            }
        }
    }

}
