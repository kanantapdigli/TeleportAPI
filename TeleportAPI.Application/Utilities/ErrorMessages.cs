using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleportAPI.Application.Utilities
{
    /// <summary>
    /// Error messages list
    /// </summary>
    public static class ErrorMessages
    {
        public static string ShouldNotBeTheSameMessage(string title) => $"{title} should not be the same";
        public static string ShouldBeEqualMessage(string title, int length) => $"{title} length should be equal to {length}";
        public static string NotFoundMessage(string title) => $"{title} not found. Please try again!";
        public static string ShouldNotBeEmptyMessage(string title) => $"{title} should not be empty!";
        public static string ErrorOccuredMessage() => "Error occured. Please try again!";
    }
}
