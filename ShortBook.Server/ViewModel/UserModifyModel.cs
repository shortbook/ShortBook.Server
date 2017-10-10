namespace ShortBook.Server.ViewModel
{
    public class UserModifyModel
    {
        public long Id { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string Name { get; set; }
    }
}