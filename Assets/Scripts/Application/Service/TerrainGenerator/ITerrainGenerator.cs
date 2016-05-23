using Application.Model.Terrain.TerrainSegments;

namespace Application.Service.TerrainGenerator
{
    public interface ITerrainGenerator
    {
        TerrainSegment GenerateNextTerrainSegment();
    }
}