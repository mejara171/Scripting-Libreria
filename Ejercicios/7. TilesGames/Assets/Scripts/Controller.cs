using Characters;
using UnityEngine;

public class Controller: MonoBehaviour
{
    [SerializeField]
    private Character character;

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space))
            character.MoveTo (Vector2.zero);
    }
}