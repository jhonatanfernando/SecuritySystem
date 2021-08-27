namespace SecuritySystem.Application.Services.Dto
{
    public interface IEntityDto<TPrimaryKey>
    {
        TPrimaryKey Id {get; set;}
    }
}