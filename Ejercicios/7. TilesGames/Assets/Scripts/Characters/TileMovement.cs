using System;
using System.Collections.Generic;
using Map;
using UnityEngine;

namespace Characters
{
    public class TileMovement: MonoBehaviour
    {
        public event Action OnFinished;
        [SerializeField]
        private float speed = 1f;
        [SerializeField]
        private float snapDistance;
        [SerializeField]
        private Tilemap map;
        private List<Vector2> path;
        private int current;
        private bool isMoving;
        private Vector2 currentPosition;

        private void Awake ()
        {
            path = new List<Vector2> ();
        }

        public void SetPath (List<Vector2> path)
        {
            if (isMoving) return;
            this.path = path;
        }

        public void MoveCurrentPath ()
        {
            isMoving = true;
            transform.position = path[current];
        }

        public void Move (List<Vector2> path)
        {
            SetPath (path);
            MoveCurrentPath ();
        }

        private void Update ()
        {
            if (!isMoving || path.Count == 0) return;
            MoveToNext ();
        }

        private void MoveToNext ()
        {
            Vector2 direction = path[current] - map.WorldToTilePosition (transform.position);
            transform.Translate (direction.normalized * (speed * Time.deltaTime));
            if (CheckIsCloseEnough (path[current]))
                SetNextDestination ();
        }

        private bool CheckIsCloseEnough (Vector2 destination)
        {
            Vector2 distance = map.TileToWorldPosition (destination) - (Vector2)transform.position;
            return distance.sqrMagnitude < snapDistance * snapDistance;
        }

        private void SetNextDestination ()
        {
            current ++;
            if (current == path.Count)
            {
                Reset ();
                if (OnFinished != null)
                    OnFinished ();
            }
        }

        private void Reset ()
        {
            isMoving = false;
            current = 0;
            path.Clear ();
        }
    }
}