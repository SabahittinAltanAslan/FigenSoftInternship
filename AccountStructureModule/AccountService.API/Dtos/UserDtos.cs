namespace AccountService.API.Dtos
{
    public record UserCreateDto(Guid UniqueInfo, string UserName, string Password
        , string Name, string Surname, string Email, string PhoneNumber, string Address);

    public record UserUpdateDto(Guid UniqueInfo, string UserName, string Password
    , string Name, string Surname, string Email, string PhoneNumber, string Address);
}
