﻿namespace Mango.Web.Utility
{
    public class SD
    {
        public static string CouponAPIbase { get; set; }
        public static string AuthAPIbase { get; set; }
        public static string CourseAPIbase { get; set; }
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";
        public const string TokenCookie = "JWTToken";

        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
    }
}
