namespace MediLabDapper.Dtos.AboutItemDtos
{
    public class GetAboutItemByIdDto
    {
        public int AboutItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int AboutId { get; set; }
    }
}
