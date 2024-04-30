using Content.Server.Maps;
using Content.Shared.Chemistry.Reaction;
using Content.Shared.Chemistry.Reagent;
using Content.Shared.FixedPoint;
using Content.Shared.Maps;
using JetBrains.Annotations;
using Robust.Shared.Map;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Chemistry.TileReactions;

[UsedImplicitly]
[DataDefinition]
public sealed partial class ReplaceTileReaction : ITileReaction
{


    [Dependency] private readonly ITileDefinitionManager _tiledef = default!;
    [Dependency] private readonly TileSystem _tilesys = default!;

    [DataField(required: true)]
    public ProtoId<ContentTileDefinition> Floor { get; set; } = default!;

    public FixedPoint2 TileReact(TileRef tile, ReagentPrototype reagent, FixedPoint2 reactVolume)
    {
        var replacementTile = (ContentTileDefinition) _tiledef[Floor];
        _tilesys.ReplaceTile(tile, replacementTile);
        return reactVolume;
    }
}
