using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public bool followPlayer = true;

    // Update is called once per frame
    void Update()
    {
        if (followPlayer) gameObject.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, gameObject.transform.position.z);
    }
}
