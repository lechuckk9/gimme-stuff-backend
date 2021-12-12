using System.Runtime.Serialization;

namespace StuffToDo.API.Lib.Models
{
    /// <summary>
    /// Sign-in DTO.
    /// </summary>
    [DataContract]
    public class SignInRequest
    {
        /// <summary>
        /// Username
        /// </summary>
        [DataMember(Name = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
