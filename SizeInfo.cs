using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Vire
{
	public class SizeInfo : EditorWindow
	{
		// Add menu item named "Size Info" to the Window menu
		[MenuItem("Window/Size Info")]
		public static void ShowWindow()
		{
			//Show existing window instance. If one doesn't exist, make one.
			EditorWindow editor = EditorWindow.GetWindow(typeof(SizeInfo));
            editor.titleContent.text = "Size Info";
		}

		void OnGUI()
		{
			// see http://forum.unity3d.com/threads/object-size.19991/
			GameObject thisObject = (GameObject)Selection.activeObject;
			if (!thisObject)
			{
				return;
			}

			MeshFilter mf = thisObject.GetComponent<MeshFilter>();
			if (!mf)
			{
				return;
			}

			Mesh mesh = mf.sharedMesh;
			if (!mesh)
			{
				return;
			}

			Vector3 size = mesh.bounds.size;
			Matrix4x4 matrix = thisObject.transform.localToWorldMatrix;

			float scaleX = matrix.m00;
			float scaleY = matrix.m11;
			float scaleZ = matrix.m22;

			EditorGUILayout.LabelField ("x", "" + size.x * scaleX);
			EditorGUILayout.LabelField ("y", "" + size.y * scaleY);
			EditorGUILayout.LabelField ("z", "" + size.z * scaleZ);
		}

		void OnInspectorUpdate()
		{
			Repaint();
		}
	}
}