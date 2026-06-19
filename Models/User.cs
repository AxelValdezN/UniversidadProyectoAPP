namespace AppDoAPI.models
{
    public class User
    {
        public int Id {get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}