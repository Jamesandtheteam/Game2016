using UnityEngine;
using UnityEditor;


class MeshPostprocessor : AssetPostprocessor
{
    void OnPreprocessModel()
    {
        (assetImporter as ModelImporter).importNormals = ModelImporterNormals.Calculate;
        (assetImporter as ModelImporter).normalSmoothingAngle = 0;
        (assetImporter as ModelImporter).importMaterials = false;
    }
}