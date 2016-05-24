using Application.Model.Terrain.TerrainSegments;

namespace Application.Model.Terrain.PathGenerator
{
    public interface IPathGenerator
    {
        TerrainSegmentPoint GetNextPoint(int index);
    }
}
