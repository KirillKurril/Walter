using System;

namespace _253504_dmi_Lab5.Entities
{
    public class CustomException : Exception
    {
        public CustomException(string message = "The element to be deleted was not found!") : base(message) 
        { }
    }
}

