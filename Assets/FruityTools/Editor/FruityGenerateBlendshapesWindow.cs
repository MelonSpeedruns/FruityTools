using UnityEditor;
using UnityEngine;
using VRM;

public class GenerateBlendshapesWindow : EditorWindow
{
    [MenuItem("Fruity Tools/Blendshapes Generator")]
    static void BlendshapesGenerator()
    {
        GenerateBlendshapesWindow window = (GenerateBlendshapesWindow)GetWindow(typeof(GenerateBlendshapesWindow));
        window.Show();
    }

    private Mesh selectedMesh;
    private GameObject selectedPrefab;

    public void OnGUI()
    {
        GUILayout.Label("VRM Prefab", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        selectedPrefab = (GameObject)EditorGUILayout.ObjectField(selectedPrefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Generate Blendshapes!"))
        {
            int blendshapeCount = selectedMesh.blendShapeCount;

            BlendShapeAvatar newAvatar = CreateInstance<BlendShapeAvatar>();

            AssetDatabase.CreateFolder("Assets", "NewBlendShapes");

            for (int i = 0; i < blendshapeCount; i++)
            {
                string blendshapeName = selectedMesh.GetBlendShapeName(i);
                BlendShapeClip clip = CreateInstance<BlendShapeClip>();
                clip.Prefab = selectedPrefab;
                clip.BlendShapeName = blendshapeName;

                BlendShapeBinding[] blendShapeBindings = new BlendShapeBinding[1];
                blendShapeBindings[0].RelativePath = selectedMesh.name.Replace(".baked", "");
                blendShapeBindings[0].Index = i;
                blendShapeBindings[0].Weight = 100f;

                clip.Values = blendShapeBindings;

                AssetDatabase.CreateAsset(clip, $"Assets/NewBlendShapes/{blendshapeName}.asset");

                clip.Prefab = selectedPrefab;
                clip.BlendShapeName = blendshapeName;
                newAvatar.Clips.Add(clip);
            }

            AssetDatabase.CreateAsset(newAvatar, $"Assets/NewBlendShapes/BlendShape.asset");
        }
    }
}