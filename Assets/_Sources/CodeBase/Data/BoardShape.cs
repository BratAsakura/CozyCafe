using UnityEngine;

[CreateAssetMenu(fileName = "BoardShape", menuName = "Board/BoardShapeCreate")]
public class BoardShape : ScriptableObject
{
    [SerializeField] private string[] _shapeData;
    public int Width => _shapeData[0].Length;
    public int Height => _shapeData.Length;

    public bool IsHole(int width, int height)
    {
        if (height < 0 || height >= Height || width < 0 || width >= Width)
            return true;

        return _shapeData[height][width] == '.';
    }
}
