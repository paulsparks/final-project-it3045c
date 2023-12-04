namespace final_project_it3045c.Models
{
    public class MemberDetails
    {
        public int Id { get; set; }

        public int TeamMemberId { get; set; }
        public TeamMember? TeamMember { get; set; }
        public string? FavoriteFood { get; set; }
        public string? FavoriteDrink { get; set; }
        public int? Age { get; set; }
        public string? FavoriteColor { get; set; }
        public string? FavoriteTVShow { get; set; }
    }
}
