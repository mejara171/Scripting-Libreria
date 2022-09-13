using UnityEditor;
using UnityEngine;

namespace Map.Detail
{
    [CustomEditor (typeof (Tilemap))]
    public class TileMapEditor: Editor
    {
        [SerializeField]
        private Vector2 size = Vector2.one;
        [SerializeField]
        private Tile prefab;

        public override void OnInspectorGUI ()
        {   
            serializedObject.Update ();
            DrawPropertiesExcluding (serializedObject, "tiles");
            size = EditorGUILayout.Vector2Field ("Size", size);
            prefab = (Tile)EditorGUILayout.ObjectField ("Tile", prefab, typeof (Tile), false);
            if (GUILayout.Button ("Generate"))
                SetTileRows(Generate ());
            serializedObject.ApplyModifiedProperties();
        }

        private TileRow[] Generate ()
        {
            TileRow[] rows = new TileRow[(int)size.y];
            float tileSize = serializedObject.FindProperty ("tileSize").floatValue;
            Transform parent = ((Tilemap)target).transform;
            for (int y=0; y < size.y; y++)
                rows[y] = GenerateRow (y, tileSize, parent);
            return rows;
        }

        private void SetTileRows (TileRow[] tiles)
        {
            Tilemap map = (Tilemap)target;
            map.tiles = tiles;
        }

        private TileRow GenerateRow (int y, float tileSize, Transform parent)
        {
            TileRow row = new TileRow ();
            Tile[] tiles = new Tile[(int)size.x];
            for (int x=0; x<size.x; x++)
                tiles[x] = InstantiateTile (new Vector2 (x, y), tileSize, parent);
            row.tiles = tiles;
            return row;
        }

        private Tile InstantiateTile (Vector2 position, float tileSize, Transform parent)
        {
            Vector2 worldPosition = position * tileSize;
            Tile tile = Instantiate (prefab, worldPosition, Quaternion.identity, parent);
            return tile;
        }
    }
}