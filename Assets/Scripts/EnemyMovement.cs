using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private const double SCREEN_END = -23.5279;
    private float START_POSITION;
    void Start(){
        START_POSITION = transform.position.x;
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x< SCREEN_END){
            GetComponent<Transform>().transform.position = new Vector2(START_POSITION, transform.position.y);
            gameObject.SetActive(false);
        }
    }
}