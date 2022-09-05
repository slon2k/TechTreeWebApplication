namespace TechTreeWebApplication.Areas.Admin.Models.Content
{
    public abstract class ContentBaseModel
    {
        public int CategoryItemId { get; set; }

        public string Title { get; set; }

        public string HTMLContent { get; set; }

        public string VideoLink { get; set; }
    }
}
