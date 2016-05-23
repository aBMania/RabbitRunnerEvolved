using Application.Model.Terrain.TerrainSegments;

namespace Application.Service.PathGenerator
{
    public interface IPathGenerator
    {
        TerrainSegmentPoint GetNextPoint(int index);
    }
}
