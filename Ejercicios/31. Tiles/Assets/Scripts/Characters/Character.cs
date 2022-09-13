using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [RequireComponent (typeof (TileMovement))]
    public class Character: MonoBehaviour
    {
        private TileMovement movement;

        private void Awake ()
        {
            movement = GetComponent<TileMovement> ();
        }

        public void MoveTo (Vector2 tile)
        {
            //TODO: pathfinding
            List<Vector2> path = GetDummyPath ();
            movement.Move (path);
        }

        private static List<Vector2> GetDummyPath ()
        {
            List<Vector2> path = new List<Vector2> ();
            path.Add (new Vector2(0, 0));
            path.Add (new Vector2(0, 1));
            path.Add (new Vector2(1, 1));
            path.Add (new Vector2(2, 1));
            path.Add (new Vector2(2, 2));
            path.Add (new Vector2(2, 3));
            return path;
        }
    }
}