namespace InventoryService.API.Dtos
{
    public record ProductCreateDto(Guid UniqueInfo, string Name, string Description
        , decimal Price, string ImageUrl);


    public record ProductUpdateDto(Guid UniqueInfo, string Name, string Description
    , decimal Price, string ImageUrl);
}
