namespace ShortBook.Server.ViewModel
{
    public class ChangePasswordModel
    {
        public long Id { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}