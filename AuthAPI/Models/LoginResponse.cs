﻿namespace AuthAPI.Models
{
    public class LoginResponse
    {
        public UserInfo User { get; set; }
        public string Token { get; set; }
    }
}
