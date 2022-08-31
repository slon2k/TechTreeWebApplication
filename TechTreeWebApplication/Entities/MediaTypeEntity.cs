using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TechTreeWebApplication.Entities
{
    public class MediaTypeEntity : Id<int>, IEntity, ITitle, IThumbnail
    {
        public int Id { get; init; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }
    }
}
