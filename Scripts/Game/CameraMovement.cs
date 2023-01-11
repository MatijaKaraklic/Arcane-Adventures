using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public float cameraSpeed = 4f;

    //public float boundX = 2f;
    //public float boundY = 1f;

    private void LateUpdate()
    {
        /*
        Vector3 delta = Vector3.zero;

        float deltaX = player.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < player.position.x) delta.x = deltaX - boundX;
            else delta.x = deltaX + boundX;
        }

        float deltaY = player.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < player.position.y) delta.y = deltaY - boundY;
            else delta.y = deltaY + boundY;
        }

        transform.position += delta;
        */


        /* LERP */
        Vector3 newPos = Vector3.Lerp(transform.position, player.position, cameraSpeed * Time.deltaTime);
        newPos.z = -10;
        transform.position = newPos;

    }

}
