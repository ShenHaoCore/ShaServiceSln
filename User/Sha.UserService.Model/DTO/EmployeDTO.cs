namespace Sha.UserService.Model.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeLoginModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        public EmployeLoginModel(string token)
        {
            this.Token = token;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
    }
}
