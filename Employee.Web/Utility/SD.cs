﻿using Microsoft.AspNetCore.SignalR;

namespace Employee.Web.Utility
{
    public class SD
    {
        public static string EmployeeAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
