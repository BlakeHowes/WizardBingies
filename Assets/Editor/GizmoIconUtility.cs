using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using UnityEditor.Sprites;
using System;

namespace FolderIcons {
    public class GizmoIconUtility {

        [DidReloadScripts]
        static GizmoIconUtility() {
            EditorApplication.projectWindowItemOnGUI += ItemOnGUI;
        }

        static void ItemOnGUI(string guid, Rect rect) {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Room room = AssetDatabase.LoadAssetAtPath(assetPath, typeof(Room)) as Room;
            if (room != null && room is Room) {
                if (!room.tile) { return; }
                if (!room.tile.m_DefaultSprite) { return; }
                if (!room.tile.m_DefaultSprite.texture) { return; }
                var texture = SpriteUtility.GetSpriteTexture(room.tile.m_DefaultSprite, true);

                Rect rbase = rect;
                if (rbase.height >= rbase.width) {
                    rbase.height -= 14; }
                else { rbase.width = 20; }

                DrawGUIRoundedBasicTexture(rbase, texture);
            }
        }

        static void DrawGUIRoundedBasicTexture(Rect _pos, Texture2D texture) {
            var colourFloat = 0.45f;
            Color colour = new Color(colourFloat, colourFloat, colourFloat);
            GUI.DrawTexture(_pos, MakeTinyTex(colour), ScaleMode.ScaleToFit, true, 1, colour, 0, _pos.width * 0.2f);
            GUI.DrawTexture(_pos, texture, ScaleMode.ScaleToFit, true, 1, Color.white, 0, _pos.width * 0.2f);
        }

        static void DrawGUIRoundedBasicColour(Rect _pos, Color colour) {
            GUI.DrawTexture(_pos, MakeTinyTex(colour), ScaleMode.ScaleToFit, true, 1, colour, 0, _pos.width * 0.2f);
        }


        static Texture2D _tex;
        static Texture2D MakeTinyTex(Color _col) {
            _tex = new Texture2D(1, 1);
            _tex.SetPixel(0, 0, _col);
            _tex.Apply();
            return _tex;
        }


    }
}
