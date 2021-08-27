namespace SecuritySystem.Application.Services.Dto
{
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; } 
    }

    public class EntityDto : EntityDto<int>
    {

    }
}