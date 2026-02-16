using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    //attribute Definition
    [AttributeUsage(AttributeTargets.Field)]
    public class MaxLengthAttribute : Attribute
    {
        public int Length { get; }
        public MaxLengthAttribute(int length)
        {
            Length = length;
        }
    }
    //applying the Attribute
    public class User
    {
        [MaxLength(10)]
        private string username;
        public User(string username)
        {
            if (username.Length > 10)
                throw new ArgumentException("Username exceeds max length");
            this.username = username;
        }
    }