﻿namespace WebAPI.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ProfileImage { get; set; }
    }
}